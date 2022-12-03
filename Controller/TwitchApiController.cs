using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.FollowerService;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace FaraBotModerator.Controller
{
    public class TwitchApiController
    {
        private readonly TwitchClientController _twitchClientController;
        private readonly TwitchAPI _twitchApi;
        // private LiveStreamMonitorService _liveStreamMonitorService;
        private readonly string _twitchUserName;
        private string _twitchChannelId;
        private FollowerService _followerService;
        private DateTime _botStartDateTime { get; } = DateTime.UtcNow;

        public TwitchApiController(TwitchClientController twitchClientController, string apiClientId, string apiSecret, string twitchUserName)
        {
            _twitchClientController = twitchClientController;
            _twitchApi = new TwitchAPI
            {
                Settings =
                {
                    ClientId = apiClientId,
                    Secret = apiSecret
                }
            };
            _twitchUserName = twitchUserName;
            _twitchChannelId = GetTwitchChannelId();
            _followerService = new FollowerService(_twitchApi, 10, 10, 100);
            _followerService.SetChannelsById(new List<string>{_twitchChannelId});
            _followerService.Start();
            _followerService.OnNewFollowersDetected += TwitchApiOnNewFollowerDetected;
            // _liveStreamMonitorService = new LiveStreamMonitorService(_twitchApi, 60);
        }

        ~TwitchApiController()
        {
            _followerService.Stop();
        }

        public string GetTwitchChannelId()
        {
            if (_twitchChannelId != null) return _twitchChannelId;
            var task = Task.Run(() => { return TwitchChannelIdAsync(); });
            return task.Result;
        }

        private async Task<string> TwitchChannelIdAsync()
        {
            // 期限が切れたらRefresh
            // userNameからuserIdを取得できる(userNameは一意なので)
            var userIds = new List<string>();
            var userLoginNames = new List<string> {_twitchUserName};
            var findUserList = await _twitchApi.Helix.Users.GetUsersAsync(userIds, userLoginNames);
            _twitchChannelId = findUserList.Users[0].Id;
            return _twitchChannelId;
        }
        
        private void TwitchApiOnNewFollowerDetected(object sender, OnNewFollowersDetectedArgs e)
        {
            var newFollowers = e.NewFollowers
                .Where(x => x.FollowedAt > _botStartDateTime)
                .Select(x => x.FromUserId)
                .ToList();
            if (newFollowers.Count > 0)
            {
                var newFollowersList = Task.Run(() =>
                {
                    return _twitchApi.Helix.Users.GetUsersAsync(newFollowers);
                });
                var users = newFollowersList.Result.Users;
                foreach (var newFollower in users)
                {
                    Task.Run(async () =>
                    {
                        _twitchClientController.SendFollowPubSubMessage(newFollower);
                        await Task.Delay(100);
                    });
                }
            }
        }
        
        private void Monitor_OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnStreamUpdate(object sender, OnStreamUpdateArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnStreamOffline(object sender, OnStreamOfflineArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnChannelsSet(object sender, OnChannelsSetArgs e)
        {
            throw new NotImplementedException();
        }

        private void Monitor_OnServiceStarted(object sender, OnServiceStartedArgs e)
        {
            throw new NotImplementedException();
        }
    }
}