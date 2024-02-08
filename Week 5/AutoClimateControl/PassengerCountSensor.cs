namespace AutoClimateControl
{
    public interface IPassengerCountSensor
    {
        void RegisterObserver(ECU observer);
        void RemoveObserver();
    }

    public class PassengerCountSensor : IPassengerCountSensor
    {
        private int peopleCount;
        private ECU? observer;
        private ITimerController timer;

        public PassengerCountSensor(ITimerController timer)
        {
            this.timer = timer;
            timer.SetTimer(5000);
            timer.SetTimerElapsedAction(new Action(ReadNumberOfPeople));
        }

        private void ReadNumberOfPeople()
        {
            Random rnd = new Random();
            peopleCount = rnd.Next(0, 5);
            NotifyObservers();
        }

        public void RegisterObserver(ECU observer)
        {
            this.observer = observer;
            timer.StartTimer();
        }

        public void RemoveObserver()
        {
            observer = null;
            timer.StopTimer();
        }

        private void NotifyObservers()
        {
            observer?.NotifyPeopleCount(peopleCount);
        }
    }
}
