using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

namespace FaraBotModerator.controllers
{
    class OBSController
    {
        private readonly OBSWebsocket _obsWebSocket;
        private string _ip;
        private string _password;
        private int _port;

        public OBSController(string ip, string password, int port)
        {
            _ip = ip;
            _password = password;
            _port = port;
            _obsWebSocket = new OBSWebsocket();
            _obsWebSocket.ConnectAsync($"ws://{_ip}:{_port}", _password);
        }

        public void SwitchEvent()
        {
            var targetSceneName = "sceneName";
            var targetSourceName = "sourceName";
            var sceneItemId = _obsWebSocket.GetSceneItemId(targetSceneName, targetSourceName, -1);
            _obsWebSocket.SetSceneItemEnabled(targetSceneName,  sceneItemId, true);
            Task.Delay(10);
            _obsWebSocket.SetSceneItemEnabled(targetSceneName,  sceneItemId, false);
        }

        public void Disconnect()
        {
            _obsWebSocket.Disconnect();
        }
    }
}
