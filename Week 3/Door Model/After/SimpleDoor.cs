using System;

namespace DoorPrototypeImproved
{
    public class SimpleDoor
    {
        protected DoorState state;
        public DoorState State { get { return state; } }
        public event Action<string> OnErrorNotify;
        public SimpleDoor()
        {
            state = DoorState.CLOSED;
        }
        public virtual void Open()
        {
            if (state == DoorState.OPENED)
            {
                OnErrorNotify?.Invoke("Door already opened");
                return;
            }
            state = DoorState.OPENED;
        }
        public virtual void Close()
        {
            if (state == DoorState.CLOSED)
            {
                OnErrorNotify?.Invoke("Door already closed");
                return;
            }
            state = DoorState.CLOSED;
        }
    }
}
