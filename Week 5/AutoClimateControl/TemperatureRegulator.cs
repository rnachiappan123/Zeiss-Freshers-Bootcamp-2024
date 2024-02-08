namespace AutoClimateControl
{
    public interface ITemperatureRegulator
    {
        void SetRequiredTemperature(int newTemperature);
    }

    public class TemperatureRegulator : ITemperatureRegulator
    {
        private int requiredTemperature;

        public void SetRequiredTemperature(int newTemperature)
        {
            requiredTemperature = newTemperature;

            if (requiredTemperature < 18)
            {
                requiredTemperature = 18;
            }
            if (requiredTemperature > 30)
            {
                requiredTemperature = 30;
            }

            Console.WriteLine($"Regulator set to {requiredTemperature}");
        }
    }
}
