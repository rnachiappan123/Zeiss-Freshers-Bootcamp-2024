namespace DoorEventAggregator
{
    public interface ISmartDoorClose
    {
        void Close();
    }
    public class SmartDoor : SimpleDoor, ISmartDoorClose
    {
        private double _timeLimit;
        public SmartDoor()
        {
            state = DoorState.CLOSED;
            EventAggregator.Instance.Subscribe<TimerElapsedEventArgs>(NotifyAddons);
        }
        public void SetTimer(double timeLimit)
        {
            _timeLimit = timeLimit;
        }
        public override void Open()
        {
            base.Open();
            EventAggregator.Instance.Publish(this, new DoorOpenEventArgs(_timeLimit));
        }
        public override void Close()
        {
            base.Close();
            EventAggregator.Instance.Publish(this, new DoorCloseEventArgs());
        }
        public void NotifyAddons(object eventArgs)
        {
            EventAggregator.Instance.Publish(this, new DoorOpenAlertEventArgs());
        }
    }
}
