using System;
using System.Threading;

namespace DoorPrototypeImproved
{
    public class Program
    {
        public static void Main()
        {
            SmartDoorBuilder smartDoorBuilder = new SmartDoorBuilder();
            SmartDoor smartDoor = smartDoorBuilder.BuildSmartDoor();
            
            AddOnFeature buzzer = new BuzzerAlertFeature();
            AddOnFeature pager = new PagerAlertFeature();
            AddOnFeature autoClose = new AutoCloseDoor(smartDoor);
            
            smartDoor.SetTimeLimit(5000);

            smartDoorBuilder.AddNewFeature(smartDoor, buzzer);
            smartDoorBuilder.AddNewFeature(smartDoor, pager);
            smartDoorBuilder.AddNewFeature(smartDoor, autoClose);

            smartDoor.Open();
            Console.WriteLine(smartDoor.State);
            Thread.Sleep(10000);
            Console.WriteLine(smartDoor.State);
        }
    }
}
