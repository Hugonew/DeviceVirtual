using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Virtual
{

    public static class UserInput
    {
        public static string GetChoice()
        {
            Console.WriteLine("Escolha a simulação que deseja executar:");
            Console.WriteLine("1. Dispositivo");
            Console.WriteLine("2. Aplicativo");
            Console.Write("Digite sua escolha (1 ou 2): ");
            return Console.ReadLine();
        }

        public static string GetDeviceType()
        {
            Console.WriteLine("Defina o tipo de dispositivo que deseja simular:");
            Console.WriteLine("1. Dispositivo de 1 canal");
            Console.WriteLine("2. Dispositivo de 2 canais");
            Console.WriteLine("3. Dispositivo de 3 canais");
            return Console.ReadLine();
        }

        public static string GetSerial()
        {
            Console.Write("Digite o serial do dispositivo: ");
            return Console.ReadLine();
        }
    }


}
