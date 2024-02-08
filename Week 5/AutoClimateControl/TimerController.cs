using Timer = System.Timers.Timer;

namespace AutoClimateControl
{
    public interface ITimerController
    {
        void SetTimer(double interval);
        void SetTimerElapsedAction(Action OnTimerElapsed);
        void StartTimer();
        void StopTimer();
    }

    public class TimerController : ITimerController
    {
        private double interval;
        private Timer? timer;
        public event Action? OnTimerElapsed;

        public void SetTimer(double interval)
        {
            this.interval = interval;
        }

        public void SetTimerElapsedAction(Action OnTimerElapsed)
        {
            this.OnTimerElapsed += OnTimerElapsed;
        }

        public void StartTimer()
        {
            timer = new Timer(interval);
            timer.Elapsed += (sender, eventArgs) => OnTimerElapsed?.Invoke();
            timer.Start();
        }

        public void StopTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }
    }
}
