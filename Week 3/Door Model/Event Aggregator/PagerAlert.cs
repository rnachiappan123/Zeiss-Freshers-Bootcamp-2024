using System;

namespace DoorEventAggregator
{
    public class PagerAlert
    {
        public PagerAlert()
        {
            EventAggregator.Instance.Subscribe<DoorOpenAlertEventArgs>(ExecuteAction);
        }
        public void ExecuteAction(object eventArgs)
        {
            Console.WriteLine("PAGER ALERT");
        }
    }
}
