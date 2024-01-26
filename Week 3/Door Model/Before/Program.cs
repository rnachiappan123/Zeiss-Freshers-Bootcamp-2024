using System;

namespace DoorPrototype
{
    public class Program
    {
        public static void Main()
        {
            SmartDoor smartDoor = new SmartDoor();
            smartDoor.SetTimeLimit(5000);

            TimerManager timer = new TimerManager();
            
            TimerManager.OnTimerElapsed += new Action(smartDoor.ExecuteSmartDoorFeatures);
            smartDoor.OnDoorOpen += new Action<double>(timer.StartTimer);
            smartDoor.OnDoorClose += new Action(timer.StopTimer);

            BuzzerAlertFeature buzzerAlert = new BuzzerAlertFeature();
            PagerAlertFeature pagerAlert = new PagerAlertFeature();
            AutoCloseFeature autoClose = new AutoCloseFeature(smartDoor);

            smartDoor.OnSmartDoorEvent += new Action(buzzerAlert.ExecuteAction);
            smartDoor.OnSmartDoorEvent += new Action(pagerAlert.ExecuteAction);
            smartDoor.OnSmartDoorEvent += new Action(autoClose.ExecuteAction);

            smartDoor.Open();
            Console.WriteLine(smartDoor.State);
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine(smartDoor.State);
        }
    }
}
