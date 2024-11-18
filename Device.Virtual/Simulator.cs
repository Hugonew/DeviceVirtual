using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using Device.Virtual;
using MQTTnet.Client;

public static class Simulator
{
    public static async Task RunSimulation(string choice, string amountCh, string serial)
    {

        string commandTopic;
        string statusTopic;
        string resetWifiTopic = $"{serial}/Cmd/ResetWifi";
        string onlineStatusTopic = $"{serial}/Status/Online";

        switch (amountCh)
        {
            case "1":
                commandTopic = $"{serial}/Cmd/Status";
                statusTopic = $"{serial}/Status/Online";
                break;
            case "2":
                commandTopic = $"{serial}/Cmd/Ch2/Power";
                statusTopic = $"{serial}/Status/Ch2/Power";
                break;
            case "3":
                commandTopic = $"{serial}/Cmd/Ch3/Power";
                statusTopic = $"{serial}/Status/Ch3/Power";
                break;
            default:
                Console.WriteLine("Opção inválida");
                return;
        }

        var mqttClientManager = new MqttClientManager();
        await mqttClientManager.ConnectAsync();
        var mqttClient = mqttClientManager.GetClient();

        switch (choice)
        {
            case "1":
                await Device.Virtual.Device.RunSimulation(mqttClient, commandTopic, statusTopic, resetWifiTopic, onlineStatusTopic);
                break;
            case "2":
                await Application.RunSimulation(mqttClient, statusTopic);
                break;
            default:
                Console.WriteLine("Escolha inválida.");
                break;
        }

        Console.WriteLine("Pressione qualquer tecla para sair.");
        Console.ReadLine();
        await mqttClientManager.DisconnectAsync();
    }
}



