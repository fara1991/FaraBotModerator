using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using FaraBotModerator.Model;
using FaraBotModerator.Properties;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace FaraBotModerator.Controller
{
    public class TwitchPubSubController
    {
        private readonly TwitchClientController _twitchClientController;

        private static TwitchPubSub _twitchPubSub;

        public TwitchPubSubController(TwitchClientController twitchClientController, string twitchChannelId)
        {
            _twitchClientController = twitchClientController;
            _twitchPubSub = new TwitchPubSub();
            _twitchPubSub.OnPubSubServiceConnected += PubSub_ServiceConnected;
            _twitchPubSub.OnListenResponse += PubSub_ListenResponse;

            // Follow
            _twitchPubSub.OnFollow += PubSub_Followed;
            _twitchPubSub.ListenToFollows(twitchChannelId);

            // Bits
            _twitchPubSub.OnBitsReceivedV2 += PubSub_BitsReceived;
            _twitchPubSub.ListenToBitsEventsV2(twitchChannelId);

            // Raid
            _twitchPubSub.OnRaidUpdateV2 += PubSub_PrepareRaid;
            _twitchPubSub.OnRaidGo += PubSub_RaidGo;
            _twitchPubSub.ListenToRaid(twitchChannelId);
            
            // Stream
            _twitchPubSub.OnStreamUp += PubSub_StreamUp;
            _twitchPubSub.OnStreamDown += PubSub_StreamDown;

            // Subscription
            _twitchPubSub.OnChannelSubscription += PubSub_ChannelSubscription;
            _twitchPubSub.ListenToSubscriptions(twitchChannelId);
            
            // ChannelPoint
            _twitchPubSub.OnChannelPointsRewardRedeemed += PubSub_ChannelPointReward;
            _twitchPubSub.ListenToChannelPoints(twitchChannelId);
            
            // Video
            _twitchPubSub.OnPrediction += PubSub_Prediction;
            _twitchPubSub.ListenToPredictions(twitchChannelId);
        }

        public void Connect()
        {
            _twitchPubSub.Connect();
        }

        public void DisConnect()
        {
            _twitchPubSub = null;
        }

        private void PubSub_ServiceConnected(object sender, EventArgs e)
        {
            _twitchPubSub.SendTopics(Settings.Default.AccessToken);
        }

        private void PubSub_ListenResponse(object sender, OnListenResponseArgs e)
        {
            if (!e.Successful)
            {
                throw new Exception($"Failed to listen! Response: {e.Response}");
            }
        }

        public void PubSub_Followed(object sender, OnFollowArgs e)
        {
            _twitchClientController.SendFollowPubSubMessage(e);
        }

        private void PubSub_BitsReceived(object sender, OnBitsReceivedV2Args e)
        {
            _twitchClientController.SendBitsPubSubMessage(e);
        }

        /// <summary>
        /// Raidコマンドを使用したときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PubSub_PrepareRaid(object sender, OnRaidUpdateV2Args e)
        {
            _twitchClientController.SendPrepareRaidPubSubMessage(e);
        }

        /// <summary>
        /// Raidをしたときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PubSub_RaidGo(object sender, OnRaidGoArgs e)
        {
            _twitchClientController.SendRaidGoPubSubMessage(e);
        }

        private void PubSub_StreamUp(object sender, OnStreamUpArgs e)
        {
            Console.WriteLine($"Stream just went up! Play delay: {e.PlayDelay}, server time: {e.ServerTime}");
        }

        private void PubSub_StreamDown(object sender, OnStreamDownArgs e)
        {
            Console.WriteLine($"Stream just went down! Server time: {e.ServerTime}");
        }

        private void PubSub_ChannelSubscription(object sender, OnChannelSubscriptionArgs e)
        {
        }

        private void PubSub_ChannelPointReward(object sender, OnChannelPointsRewardRedeemedArgs e)
        {
        }

        private void PubSub_Prediction(object sender, OnPredictionArgs e)
        {
        }
    }
}