using System;

namespace DoorEventAggregator
{
    public class AutoClose
    {
        private readonly ISmartDoorClose smartDoor;
        public AutoClose(ISmartDoorClose smartDoor)
        {
            this.smartDoor = smartDoor;
            EventAggregator.Instance.Subscribe<DoorOpenAlertEventArgs>(ExecuteAction);
        }
        public void ExecuteAction(object eventArgs)
        {
            smartDoor.Close();
            Console.WriteLine("Smart door automatically closed");
        }
    }
}
