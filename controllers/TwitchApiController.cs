using System.Collections.Generic;
using System.Threading.Tasks;
using FaraBotModerator.models;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.Users.GetUsers;

namespace FaraBotModerator.controllers;

/// <summary>
/// </summary>
public class TwitchApiController
{
    private readonly TwitchAPI _twitchApi;

    /// <summary>
    ///     Twitch API経由の操作をするController
    /// </summary>
    /// <param name="secretKeys"></param>
    public TwitchApiController(SecretKeyModel secretKeys)
    {
        _twitchApi = new TwitchAPI
        {
            Settings =
            {
                ClientId = secretKeys.Twitch.Api.ClientId,
                Secret = secretKeys.Twitch.Api.Secret
            }
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public string GetTwitchChannelId(string userName)
    {
        var task = Task.Run(() => TwitchChannelIdAsync(userName));
        return task.Result.Id;
    }

    /// <summary>
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public string GetTwitchIconUrl(string userName)
    {
        var task = Task.Run(() => TwitchChannelIdAsync(userName));
        return task.Result.ProfileImageUrl;
    }

    /// <summary>
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    private async Task<User> TwitchChannelIdAsync(string userName)
    {
        // 期限が切れたらRefresh
        // userNameからuserIdを取得できる(userNameは一意なので)
        var userIds = new List<string>();
        var userLoginNames = new List<string> {userName};
        var findUserList = await _twitchApi.Helix.Users.GetUsersAsync(userIds, userLoginNames);
        return findUserList.Users[0];
    }
}