using System;
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

            // TODO この辺実装する Raidは欲しい情報ないので実装しない
            // Bits
            _twitchPubSub.OnBitsReceivedV2 += PubSub_BitsReceived;
            _twitchPubSub.ListenToBitsEventsV2(twitchChannelId);

            // Stream
            _twitchPubSub.OnStreamUp += PubSub_StreamUp;
            _twitchPubSub.OnStreamDown += PubSub_StreamDown;

            // ChannelPoint
            _twitchPubSub.OnChannelPointsRewardRedeemed += PubSub_ChannelPointReward;
            _twitchPubSub.ListenToChannelPoints(twitchChannelId);
            
            // Prediction
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
            _twitchClientController.TwitchPubSubOnFollow(e);
        }

        private void PubSub_BitsReceived(object sender, OnBitsReceivedV2Args e)
        {
            _twitchClientController.SendBitsPubSubMessage(e);
        }

        private void PubSub_StreamUp(object sender, OnStreamUpArgs e)
        {
            Console.WriteLine($"Stream just went up! Play delay: {e.PlayDelay}, server time: {e.ServerTime}");
        }

        private void PubSub_StreamDown(object sender, OnStreamDownArgs e)
        {
            Console.WriteLine($"Stream just went down! Server time: {e.ServerTime}");
        }

        private void PubSub_ChannelPointReward(object sender, OnChannelPointsRewardRedeemedArgs e)
        {
            _twitchClientController.SendChannelPointPubSubMessage(e);
        }

        private void PubSub_Prediction(object sender, OnPredictionArgs e)
        {
            _twitchClientController.SendPredictionPubSubMessage(e);
        }
    }
}