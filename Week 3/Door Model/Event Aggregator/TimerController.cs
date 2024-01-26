using System.Timers;

namespace DoorEventAggregator
{
    public class TimerController
    {
        Timer timer;
        public TimerController()
        {
            EventAggregator.Instance.Subscribe<DoorOpenEventArgs>(StartTimer);
            EventAggregator.Instance.Subscribe<DoorCloseEventArgs>(StopTimer);
        }
        public void StartTimer(object eventArgs)
        {
            DoorOpenEventArgs doorOpenedEventArgs = eventArgs as DoorOpenEventArgs;
            if (doorOpenedEventArgs == null)
            {
                EventAggregator.Instance.Publish(this, new ErrorEventArgs("Error: Could not parse DoorOpenEventArgs"));
                return;
            }
            timer = new Timer(doorOpenedEventArgs.TimeLimit);
            timer.Elapsed += (sender, e) => { EventAggregator.Instance.Publish(this, new TimerElapsedEventArgs()); };
            timer.Start();
        }
        public void StopTimer(object eventArgs)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }
    }
}
