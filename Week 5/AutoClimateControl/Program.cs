namespace AutoClimateControl;

class Program
{
    static void Main()
    {
        ECU ecu = new ECU();

        AutoClimateController climateController = new AutoClimateController(ecu);

        climateController.On();

        Console.WriteLine("Auto climate control is on. Waiting for sensor data...");

        System.Threading.Thread.Sleep(30000);

        climateController.Off();
    }
}