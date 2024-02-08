namespace AutoClimateControl
{
    public interface IOutsideTemperatureSensor
    {
        void RegisterObserver(ECU observer);
        void RemoveObserver();
    }

    public class OutsideTemperatureSensor : IOutsideTemperatureSensor
    {
        private int temperature;
        private ECU? observer;
        private ITimerController timer;

        public OutsideTemperatureSensor(ITimerController timer)
        {
            this.timer = timer;
            timer.SetTimer(3000);
            timer.SetTimerElapsedAction(new Action(ReadTemperature));
        }

        private void ReadTemperature()
        {
            Random rnd = new Random();
            temperature = rnd.Next(15, 45);
            NotifyObservers();
        }

        public void RegisterObserver(ECU observer)
        {
            this.observer = observer;
            timer.StartTimer();
        }

        public void RemoveObserver()
        {
            this.observer = null;
            timer.StopTimer();
        }

        private void NotifyObservers()
        {
            observer?.NotifyTemperature(temperature);
        }
    }
}
