using MQTTnet;
using MQTTnet.Client;

namespace Breadr.MQTT
{
    public static class MqttSender
    {
        
        public static async Task MqttSend(string gateId,string operation = "open")
        {
  
            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
            .WithClientId("API-sender")
            .WithTcpServer("test.mosquitto.org",1883)
            .WithCleanSession()
            .Build();

            await client.ConnectAsync(options);

            string payload= "{\"gate\":\"" + gateId + "\",\"operation\": \"" + operation + "\"}";

            var message = new MqttApplicationMessageBuilder()
            .WithTopic("foi/air2220")
            .WithPayload(payload)
            .Build();

            if (client.IsConnected)
            {
                await client.PublishAsync(message);
            }

            await client.DisconnectAsync();

        }

    }
}
