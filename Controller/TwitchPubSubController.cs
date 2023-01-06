using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using FaraBotModerator.Model;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace FaraBotModerator.Controller
{
    public class TwitchPubSubController
    {
        private readonly TwitchClientController _twitchClientController;
        private static TwitchPubSub _twitchPubSub;
        private readonly string _twitchApiClientId;
        private readonly string _twitchApiAccessToken;
        private readonly string _twitchApiSecret;
        private readonly string _twitchChannelId;

        public TwitchPubSubController(TwitchClientController twitchClientController, string twitchChannelId, string twitchAccessToken,
            string twitchApiClientId, string twitchApiSecret)
        {
            // 認証が通ってないらしい？
            _twitchClientController = twitchClientController;
            _twitchPubSub = new TwitchPubSub();
            _twitchApiClientId = twitchApiClientId;
            _twitchApiAccessToken = twitchAccessToken;
            _twitchApiSecret = twitchApiSecret;
            _twitchChannelId = twitchChannelId;

            _twitchPubSub.OnPubSubServiceConnected += TwitchPubSubOnPubSubServiceConnected;
            _twitchPubSub.OnBitsReceivedV2 += TwitchPubSubBitsReceived;
            // _twitchPubSub.OnRaidUpdateV2 += TwitchPubSubOnPrepareRaid;
            // _twitchPubSub.OnRaidGo += TwitchPubSubOnRaidGo;
            _twitchPubSub.OnStreamUp += TwitchPubSubOnStreamUp;
            _twitchPubSub.OnStreamDown += TwitchPubSubOnStreamDown;

            _twitchPubSub.OnFollow += PubSub_OnFollow;
            _twitchPubSub.ListenToFollows(_twitchChannelId);
            // ここで通知を検知するユーザを指定(現状は自分のみ)
            _twitchPubSub.ListenToBitsEventsV2(_twitchChannelId);
            _twitchPubSub.OnListenResponse += TwitchPubSubOnListenResponse;
            // _twitchPubSub.ListenToRaid(twitchChannelId);
            // _twitchPubSub.ListenToSubscriptions(twitchChannelId);
            // _twitchPubSub.ListenToChannelPoints(twitchChannelId);
            // _twitchPubSub.ListenToVideoPlayback("channelUsername");
        }

        public void PubSub_OnFollow(object sender, OnFollowArgs e)
        {
            var a = 1;
            var b = e.Username;

        }
        
        public void Connect()
        {
            // var oauthTokenResult = TwitchResponseOAuthToken();
            _twitchPubSub.Connect();
        }

        public void DisConnect()
        {
            _twitchPubSub = null;
        }

        private void TwitchPubSubBitsReceived(object sender, OnBitsReceivedV2Args e)
        {
            var bits = e.BitsUsed;
            var totalBits = e.TotalBitsUsed;
            var a = e.UserName;
            _twitchClientController.SendBitsPubSubMessage(e);
        }

        private void TwitchPubSubOnPrepareRaid(object sender, OnRaidUpdateV2Args e)
        {
            var a = e.Id;
            var b = "test";
        }

        private void TwitchPubSubOnRaidGo(object sender, OnRaidGoArgs e)
        {
            var a = e.Id;
            var b = "test";
        }

        private void TwitchPubSubOnPubSubServiceConnected(object sender, EventArgs e)
        {
            _twitchPubSub.SendTopics(_twitchApiAccessToken);
        }

        private void TwitchPubSubOnListenResponse(object sender, OnListenResponseArgs e)
        {
            if (!e.Successful)
            {
                throw new Exception($"Failed to listen! Response: {e.Response}");
            }
        }

        private void TwitchPubSubOnStreamUp(object sender, OnStreamUpArgs e)
        {
            Console.WriteLine($"Stream just went up! Play delay: {e.PlayDelay}, server time: {e.ServerTime}");
        }

        private void TwitchPubSubOnStreamDown(object sender, OnStreamDownArgs e)
        {
            Console.WriteLine($"Stream just went down! Server time: {e.ServerTime}");
        }

        private async Task<TwitchOAuthTokenModel> TwitchResponseOAuthToken()
        {
            using (var httpClient = new HttpClient())
            {
                var parameter =
                    $"client_id={_twitchApiClientId}" +
                    $"&client_secret={_twitchApiSecret}" +
                    "&code=yro086hsolzz6od15748irpa9fmunl" +
                    "&grant_type=authorization_code" +
                    "&redirect_uri=http://localhost";
                // var parameter =
                    // $"grant_type=client_credentials&client_id={_twitchApiClientId}&client_secret={_twitchApiSecret}";
                var content = new StringContent(parameter, Encoding.Default, "application/x-www-form-urlencoded");
                var response = await httpClient.PostAsync("https://id.twitch.tv/oauth2/token", content);

                var responseBody = response.Content.ReadAsStringAsync().Result;
                var option = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                var jsonString =
                    JsonSerializer.Deserialize<TwitchOAuthTokenModel>(responseBody,
                        option);
                var secretKeys = new SecretKeyModel
                {
                    Twitch = new TwitchSecretKeyModel
                    {
                        Client = new TwitchClientKeyModel(),
                        Api = new TwitchApiKeyModel(),
                        PubSub = new TwitchPubSubKeyModel()
                    },
                    Twitter = new TwitterKeyModel(),
                    DeepL = new DeepLKeyModel()
                };
                using (var writer = new StreamWriter("secrets.json"))
                {
                    var writerOption = new JsonSerializerOptions {WriteIndented = true};
                    var jsonData = JsonSerializer.Serialize(secretKeys, writerOption);
                    writer.WriteLine(jsonData);
                }

                return jsonString;
            }
        }
    }
}