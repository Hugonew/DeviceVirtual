using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;


namespace Device.Virtual
{
    public class MqttClientManager
    {
        private readonly IMqttClient _mqttClient;

        public MqttClientManager()
        {
            _mqttClient = new MqttFactory().CreateMqttClient();
        }

        public async Task ConnectAsync()
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .Build();

            try
            {
                await _mqttClient.ConnectAsync(options);
                Console.WriteLine("Conectado ao broker MQTT.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar: {ex.Message}");
            }
        }

        public async Task DisconnectAsync()
        {
            if (_mqttClient.IsConnected)
            {
                await _mqttClient.DisconnectAsync();
                Console.WriteLine("Desconectado do broker MQTT.");
            }
        }

        public IMqttClient GetClient()
        {
            return _mqttClient;
        }
    }


}
