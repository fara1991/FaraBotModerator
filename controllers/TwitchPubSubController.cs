using System;
using FaraBotModerator.Properties;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace FaraBotModerator.controllers;

/// <summary>
///     Twitch PubSub経由の操作をするController
/// </summary>
public class TwitchPubSubController
{
    private static TwitchPubSub? _twitchPubSub;
    private readonly TwitchClientController _twitchClientController;

    /// <summary>
    /// </summary>
    /// <param name="twitchClientController"></param>
    /// <param name="twitchChannelId"></param>
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

    /// <summary>
    /// </summary>
    public void Connect()
    {
        _twitchPubSub?.Connect();
    }

    /// <summary>
    /// </summary>
    public void Disconnect()
    {
        _twitchPubSub?.Disconnect();
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PubSub_ServiceConnected(object? sender, EventArgs e)
    {
        _twitchPubSub?.SendTopics(Settings.Default.AccessToken);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="Exception"></exception>
    private void PubSub_ListenResponse(object? sender, OnListenResponseArgs e)
    {
        _twitchClientController.TwitchPubSubOnListen(e);
    }


    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void PubSub_Followed(object? sender, OnFollowArgs e)
    {
        _twitchClientController.TwitchPubSubOnFollow(e);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PubSub_BitsReceived(object? sender, OnBitsReceivedV2Args e)
    {
        _twitchClientController.SendBitsPubSubMessage(e);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PubSub_StreamUp(object? sender, OnStreamUpArgs e)
    {
        Console.WriteLine($"Stream just went up! Play delay: {e.PlayDelay}, server time: {e.ServerTime}");
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PubSub_StreamDown(object? sender, OnStreamDownArgs e)
    {
        Console.WriteLine($"Stream just went down! Server time: {e.ServerTime}");
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PubSub_ChannelPointReward(object? sender, OnChannelPointsRewardRedeemedArgs e)
    {
        _twitchClientController.SendChannelPointPubSubMessage(e);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PubSub_Prediction(object? sender, OnPredictionArgs e)
    {
        _twitchClientController.SendPredictionPubSubMessage(e);
    }
}