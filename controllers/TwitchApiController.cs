using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FaraBotModerator.models;
using FaraBotModerator.Properties;
using TwitchLib.Api;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Helix.Models.EventSub;
using TwitchLib.Api.Helix.Models.Users.GetUsers;

namespace FaraBotModerator.controllers;

/// <summary>
/// </summary>
public class TwitchApiController
{
    private readonly TwitchAPI _twitchApi;
    private readonly SecretKeyModel _secretKeyModel;
    private readonly User _myUserInfo;

    /// <summary>
    ///     Twitch API経由の操作をするController
    /// </summary>
    /// <param name="secretKeyModel"></param>
    public TwitchApiController(SecretKeyModel secretKeyModel)
    {
        _secretKeyModel = secretKeyModel;
        _twitchApi = new TwitchAPI
        {
            Settings =
            {
                ClientId = _secretKeyModel.Twitch.Api.ClientId,
                Secret = _secretKeyModel.Twitch.Api.Secret,
                AccessToken = Settings.Default.AccessToken
            }
        };
        _myUserInfo = Task.Run(() => TwitchChannelIdAsync(_secretKeyModel.Twitch.Client.UserName)).Result;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public string GetTwitchChannelId()
    {
        return _myUserInfo.Id;
    }

    /// <summary>
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public string GetTwitchIconUrl(string userName)
    {
        var user = TwitchChannelIdAsync(userName);
        return user.ProfileImageUrl;
    }

    /// <summary>
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    private User TwitchChannelIdAsync(string userName)
    {
        // 期限が切れたらRefresh
        // userNameからuserIdを取得できる(userNameは一意なので)
        var userIds = new List<string>();
        var userLoginNames = new List<string> {userName};
        var findUserList = Task.Run(() => _twitchApi.Helix.Users.GetUsersAsync(userIds, userLoginNames)).Result;
        return findUserList.Users[0];
    }

    /// <summary>
    /// </summary>
    /// <param name="myUserName"></param>
    /// <param name="raiderUserName"></param>
    /// <param name="accessToken"></param>
    /// <returns></returns>
    public async Task SendShoutoutAsync(string myUserName, string raiderUserName)
        // public async Task SendShoutoutAsync(string myUserName, string raiderUserName, string accessToken)
    {
        // 配信中に動くか検証
        var users =
            await _twitchApi.Helix.Users.GetUsersAsync(new List<string>(),
                new List<string> {myUserName, raiderUserName});
        await _twitchApi.Helix.Chat.SendShoutoutAsync(users.Users[0].Id, users.Users[1].Id,
            users.Users[0].Id);
        // await _twitchApi.Helix.Chat.SendShoutoutAsync(users.Users[0].Id, users.Users[1].Id,
        //     users.Users[0].Id, accessToken);
    }

    private async Task CreateEventSubSubscriptionAsync(string subscriptionType, string version,
        Dictionary<string, string> conditions, string sessionId)
    {
        try
        {
            await _twitchApi.Helix.EventSub.CreateEventSubSubscriptionAsync(
                subscriptionType, version, conditions, EventSubTransportMethod.Websocket, sessionId);
        }
        catch (Exception e)
        {
            LogController.OutputLog(e.ToString());
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task CreateEventSubFollowAsync(string sessionId)
    {
        var conditions = new Dictionary<string, string>
        {
            {"broadcaster_user_id", _myUserInfo.Id},
            {"moderator_user_id", _myUserInfo.Id}
        };
        await CreateEventSubSubscriptionAsync("channel.follow", "2", conditions, sessionId);
    }

    public async Task CreateEventSubCheerAsync(string sessionId)
    {
        // bits:read
        var conditions = new Dictionary<string, string>
        {
            {"broadcaster_user_id", _myUserInfo.Id}
        };
        await CreateEventSubSubscriptionAsync("channel.cheer", "1", conditions, sessionId);
    }

    public async Task CreateEventSubChannelPointAsync(string sessionId)
    {
        var conditions = new Dictionary<string, string>
        {
            {"broadcaster_user_id", _myUserInfo.Id}
        };
        await CreateEventSubSubscriptionAsync("channel.channel_points_custom_reward_redemption.add", "1", conditions, sessionId);
    }

    public bool ValidateToken()
    {
        try
        {
            var validation = Task.Run(() => _twitchApi.Auth.ValidateAccessTokenAsync()).Result;
            // _twitchApi.Settings.Scopes = validation.Scopes;
            LogController.OutputLog(
                $"Token is valid. Client ID: {validation.ClientId}, User ID: {validation.UserId}, Expires in: {validation.ExpiresIn} seconds");
            return true;
        }
        catch (Exception ex)
        {
            LogController.OutputLog($"Token validation failed: {ex.Message}");
            return false;
        }
    }
}