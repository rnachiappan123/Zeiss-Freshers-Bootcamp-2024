using System;

namespace DoorPrototype
{
    public enum DoorState { OPENED, CLOSED }
    public interface IDoor
    {
        void Open();
        void Close();
    }
    public abstract class Door : IDoor
    {
        public DoorState State;
        public abstract void Open();
        public abstract void Close();
    }
    public class SimpleDoor : Door
    {
        public SimpleDoor() { State = DoorState.CLOSED; }
        public override void Open()
        {
            if (State == DoorState.OPENED) { throw new InvalidOperationException("Door already opened"); }
            State = DoorState.OPENED;
        }
        public override void Close()
        {
            if (State == DoorState.CLOSED) { throw new InvalidOperationException("Door already closed"); }
            State = DoorState.CLOSED;
        }
    }
    public class SmartDoor : SimpleDoor
    {
        private double _timeLimit;
        public SmartDoor() { State = DoorState.CLOSED; }
        public void SetTimeLimit(double timeLimit) { _timeLimit = timeLimit; }
        
        public event Action<double> OnDoorOpen;
        public event Action OnDoorClose;
        public event Action OnSmartDoorEvent;
        public override void Open()
        {
            base.Open();
            OnDoorOpen?.Invoke(_timeLimit);
        }
        public override void Close()
        {
            base.Close();
            OnDoorClose?.Invoke();
        }
        public void ExecuteSmartDoorFeatures()
        {
            OnSmartDoorEvent?.Invoke();
        }
    }
}
