using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api;

namespace FaraBotModerator.Controller
{
    public class TwitchApiController
    {
        private readonly TwitchAPI _twitchApi;
        private readonly string _twitchUserName;
        private string _twitchChannelId;

        public TwitchApiController(string apiClientId, string apiSecret, string twitchUserName)
        {
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
        }

        public string GetTwitchChannelId()
        {
            if (_twitchChannelId != null) return _twitchChannelId;
            var task = Task.Run(TwitchChannelIdAsync);
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
    }
}