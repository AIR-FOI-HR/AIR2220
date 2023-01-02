using Azure;
using Breadr.Controllers;
using DataAccess.Models;
using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Server;
using System.Text;

namespace Breadr.MQTT
{
    public static class MqttReceiver
    {
        //public static string Address = "air2220.mobilisis.hr/api/";
        public static async Task KeepAliveListener()
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
                    var table = substrng[1].Split(",");
                    Console.WriteLine(table[0].Replace("\"", ""));

                    /*using (var webClient = new System.Net.WebClient())
                    {
                        data =
                        webClient.UploadData(Address, "PUT", data);
                    }*/
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
