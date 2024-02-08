namespace AutoClimateControl
{
    public interface ITemperatureCalculator
    {
        int CalculateNewTemperature(int newTemperature, int newPeopleCount);
    }

    public class TemperatureCalculator : ITemperatureCalculator
    {
        public int CalculateNewTemperature(int outsideTemp, int numPeople)
        {
            return Convert.ToInt32(Math.Round(25 - (outsideTemp-25)*numPeople*0.1));
        }
    }
}
