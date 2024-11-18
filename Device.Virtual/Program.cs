using Device.Virtual;
using System.Threading.Tasks;

namespace Device.Virtual
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string choice = UserInput.GetChoice();
            string amountCh = UserInput.GetDeviceType();
            string serial = UserInput.GetSerial();

            await Simulator.RunSimulation(choice, amountCh, serial);
        }
    }
}
