using System;

namespace DoorPrototypeImproved
{
    public class SmartDoorBuilder
    {
        public SmartDoor BuildSmartDoor()
        {
            SmartDoor smartDoor = new SmartDoor();
            TimerController timer = new TimerController();
            timer.OnTimerElapsed += new Action(smartDoor.ExecuteAddons);
            smartDoor.SetTimer(timer);
            return smartDoor;
        }
        public void AddNewFeature(SmartDoor smartDoor, AddOnFeature feature)
        {
            smartDoor.NotifyAddons += new Action(feature.ExecuteAction);
        }
    }
}
