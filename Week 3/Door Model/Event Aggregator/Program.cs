using System.Threading;

namespace DoorEventAggregator
{
    public class Program
    {
        public static void Main()
        {
            ErrorEventHandler errorEventHandler = new ErrorEventHandler();
            TimerController timerController = new TimerController();
            SmartDoor smartDoor = new SmartDoor();
            BuzzerAlert buzzerAlert = new BuzzerAlert();
            PagerAlert pagerAlert = new PagerAlert();
            AutoClose autoClose = new AutoClose(smartDoor);

            smartDoor.SetTimer(5000);
            smartDoor.Open();
            Thread.Sleep(10000);
        }
    }
}
