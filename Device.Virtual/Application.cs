using System;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace Device.Virtual
{
    public class Application
    {
        public static async Task RunSimulation(IMqttClient mqttClient, string statusTopic)
        {
            try
            {
                await mqttClient.SubscribeAsync(statusTopic);
                mqttClient.ApplicationMessageReceivedAsync += async e => await ChegouMensagemDoTopicoSub(e, mqttClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static async Task ChegouMensagemDoTopicoSub(MqttApplicationMessageReceivedEventArgs e, IMqttClient mqttClient)
        {
            Console.WriteLine("Mensagem recebida pelo aplicativo.");
            Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
            Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");

            var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            if (message == "ON")
            {
                Console.WriteLine("Dispositivo ligado.");
            }
            else if (message == "OFF")
            {
                Console.WriteLine("Dispositivo desligado.");
            }
        }
    }
}
