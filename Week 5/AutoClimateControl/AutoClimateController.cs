namespace AutoClimateControl
{
    public class AutoClimateController
    {
        private ECU ecu;

        public AutoClimateController(ECU ecuInstance)
        {
            ecu = ecuInstance;
            ecu.SetOutsideTemperatureSensor(new OutsideTemperatureSensor(new TimerController()));
            ecu.SetPassengerCountSensor(new PassengerCountSensor(new TimerController()));
            ecu.SetTemperatureCalculator(new TemperatureCalculator());
            ecu.SetTemperatureRegulator(new TemperatureRegulator());
        }

        public void On()
        {
            ecu.temperatureSensor?.RegisterObserver(ecu);
            ecu.peopleSensor?.RegisterObserver(ecu);
        }

        public void Off()
        {
            ecu.temperatureSensor?.RemoveObserver();
            ecu.peopleSensor?.RemoveObserver();
        }
    }
}
