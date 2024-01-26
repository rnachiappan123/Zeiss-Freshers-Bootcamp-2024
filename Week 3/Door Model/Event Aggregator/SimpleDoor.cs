namespace DoorEventAggregator
{
    public enum DoorState
    {
        OPENED,
        CLOSED
    }
    public class SimpleDoor
    {
        protected DoorState state;
        public SimpleDoor()
        {
            state = DoorState.CLOSED;
        }
        public virtual void Open()
        {
            if (state == DoorState.OPENED)
            {
                EventAggregator.Instance.Publish(this, new ErrorEventArgs("Cannot open door: Door is already opened"));
                return;
            }
            state = DoorState.OPENED;
        }
        public virtual void Close()
        {
            if (state == DoorState.CLOSED)
            {
                EventAggregator.Instance.Publish(this, new ErrorEventArgs("Cannot close door: Door is already closed"));
                return;
            }
            state = DoorState.CLOSED;
        }
    }
}
