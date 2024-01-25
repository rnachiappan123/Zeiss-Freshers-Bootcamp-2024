using System;

namespace DoorPrototypeImproved
{
    public class SmartDoor : SimpleDoor, ISmartDoorClose
    {
        private double _timeLimit;
        private ITimerController _timer;
        public event Action NotifyAddons;
        public SmartDoor()
        {
            state = DoorState.CLOSED;
        }
        public void SetTimer(ITimerController timer)
        {
            _timer = timer;
        }
        public void SetTimeLimit(double timeLimit)
        {
            _timeLimit = timeLimit;
        }
        public override void Open()
        {
            base.Open();
            _timer.StartTimer(_timeLimit);
        }
        public override void Close()
        {
            base.Close();
            _timer.StopTimer();
        }
        public void ExecuteAddons()
        {
            NotifyAddons?.Invoke();
        }
    }
}
