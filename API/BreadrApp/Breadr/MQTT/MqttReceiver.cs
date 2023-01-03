using Azure;
using Breadr.Controllers;
using DataAccess.Models;
using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Server;
using System.Text;
using Breadr.Service.Gate;
using AutoMapper;
using Azure.Core;
using Breadr.Service.Gate.Models;
using Breadr.ViewModels;

namespace Breadr.MQTT
{
    public static class MqttReceiver
    {
        public static async Task KeepAliveListener(GateController gateController)
        {
            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
            .WithClientId("API-listener")
            .WithTcpServer("test.mosquitto.org", 1883)
            .WithCleanSession()
            .Build();

            client.ApplicationMessageReceivedAsync += e =>
            {
                var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                if (message.Contains("keepalive"))
                {
                    var substrng = message.Split(':');
                    var target = substrng[1].Split(",");
                    var gateId = target[0].Replace("\"", "");

                    var gate = new GateViewModel();
                    gate.GateId = gateId;
                    gate.Keepalive = DateTime.Now;


                    gateController.Keepalive(gate);

                }
                return Task.CompletedTask;
            };

            await client.ConnectAsync(options);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(
                    f =>
                    {
                        f.WithTopic("foi/air2220");
                    })
                .Build();

            await client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }
    }
}
