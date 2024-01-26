using System;

namespace DoorEventAggregator
{
    public class BuzzerAlert
    {
        public BuzzerAlert()
        {
            EventAggregator.Instance.Subscribe<DoorOpenAlertEventArgs>(ExecuteAction);
        }
        public void ExecuteAction(object eventArgs)
        {
            Console.WriteLine("BUZZER ALERT");
        }
    }
}
