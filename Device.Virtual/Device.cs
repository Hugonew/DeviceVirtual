using System;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace Device.Virtual
{
    public class Device
    {
        public static async Task RunSimulation(IMqttClient mqttClient, string commandTopic, string statusTopic, string resetWifiTopic, string onlineStatusTopic)
        {
            try
            {
                await mqttClient.SubscribeAsync(commandTopic);
                await mqttClient.SubscribeAsync(resetWifiTopic);
                await mqttClient.SubscribeAsync(onlineStatusTopic);
                Console.WriteLine("Inscrito em tópicos.");

                mqttClient.ApplicationMessageReceivedAsync += async e => await ChegouMensagemDoTopicoSub(e, mqttClient, statusTopic, resetWifiTopic, onlineStatusTopic);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static async Task ChegouMensagemDoTopicoSub(MqttApplicationMessageReceivedEventArgs e, IMqttClient mqttClient, string statusTopic, string resetWifiTopic, string onlineStatusTopic)
        {
            Console.WriteLine("Mensagem recebida.");
            Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
            Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");

            var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            MqttApplicationMessage responseMessage = null;

            switch (message)
            {
                case "ON":
                    Console.WriteLine("Dispositivo ligado.");
                    responseMessage = new MqttApplicationMessageBuilder()
                        .WithTopic(statusTopic)
                        .WithPayload("ON")
                        .Build();
                    break;

                case "ALLINFO":
                    Console.WriteLine("Diagnostico do dispositivo");
                    responseMessage = new MqttApplicationMessageBuilder().
                        WithTopic(onlineStatusTopic).
                        WithPayload("DEVICE-A1033*FIRMWARE_BUILD-1WIFI-90%POWERTIME-1d:18h:27m:28sALARMS-OKNTP-0d:3h:14m:35sINPUT1-0OUTPUT1-0INPUT2-1OUTPUT2-0INPUT3-1*OUTPUT3-0").
                        Build();
                    break;

                case "OFF":
                    Console.WriteLine("Dispositivo desligado.");
                    responseMessage = new MqttApplicationMessageBuilder()
                        .WithTopic(statusTopic)
                        .WithPayload("OFF")
                        .Build();
                    break;

                case "ResetWifi":
                    Console.WriteLine("Reset Wifi");
                    responseMessage = new MqttApplicationMessageBuilder()
                        .WithTopic(onlineStatusTopic)
                        .WithPayload("WiFi not reset")
                        .Build();
                    break;

                case "Connect":
                    Console.WriteLine("Connected");
                    responseMessage = new MqttApplicationMessageBuilder()
                        .WithTopic(onlineStatusTopic)
                        .WithPayload("YES")
                        .Build();
                    break;

                case "Disconnect":
                    Console.WriteLine("Disconnected");
                    responseMessage = new MqttApplicationMessageBuilder()
                        .WithTopic(onlineStatusTopic)
                        .WithPayload("NO")
                        .Build();
                    break;
            }

            if (responseMessage != null)
            {
                await mqttClient.PublishAsync(responseMessage);
            }
        }
    }
}
