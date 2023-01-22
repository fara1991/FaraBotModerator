using System.Collections.Generic;
using System.Threading.Tasks;
using FaraBotModerator.Model;
using TwitchLib.Api;

namespace FaraBotModerator.Controller
{
    public class TwitchApiController
    {
        private readonly TwitchAPI _twitchApi;

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

        public string GetTwitchChannelId(string userName)
        {
            var task = Task.Run(() => TwitchChannelIdAsync(userName));
            return task.Result;
        }

        private async Task<string> TwitchChannelIdAsync(string userName)
        {
            // 期限が切れたらRefresh
            // userNameからuserIdを取得できる(userNameは一意なので)
            var userIds = new List<string>();
            var userLoginNames = new List<string> {userName};
            var findUserList = await _twitchApi.Helix.Users.GetUsersAsync(userIds, userLoginNames);
            return findUserList.Users[0].Id;
        }
    }
}