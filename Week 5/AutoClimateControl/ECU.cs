namespace AutoClimateControl
{
    public class ECU
    {
        public IOutsideTemperatureSensor? temperatureSensor;
        public IPassengerCountSensor? peopleSensor;

        public ITemperatureCalculator? calculator;
        public ITemperatureRegulator? regulator;

        private int lastReadTemperature;
        private int lastReadPeopleCount;

        public void SetOutsideTemperatureSensor(IOutsideTemperatureSensor temperatureSensor)
        {
            this.temperatureSensor = temperatureSensor;
        }

        public void SetPassengerCountSensor(IPassengerCountSensor peopleSensor)
        {
            this.peopleSensor = peopleSensor;
        }

        public void SetTemperatureCalculator(ITemperatureCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void SetTemperatureRegulator(ITemperatureRegulator regulator)
        {
            this.regulator = regulator;
        }

        public void SetNewTemperature()
        {
            if (calculator != null)
            {
                int newTemperature = calculator.CalculateNewTemperature(lastReadTemperature, lastReadPeopleCount);
                regulator?.SetRequiredTemperature(newTemperature);
            }
        }

        public void NotifyTemperature(int newTemperature)
        {
            lastReadTemperature = newTemperature;
            SetNewTemperature();
        }

        public void NotifyPeopleCount(int newCount)
        {
            lastReadPeopleCount = newCount;
            SetNewTemperature();
        }
    }
}
