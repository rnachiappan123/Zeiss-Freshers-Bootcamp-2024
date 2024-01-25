using System;
using System.Timers;

namespace DoorPrototypeImproved
{
    public class TimerController : ITimerController
    {
        Timer m_Timer;
        public event Action OnTimerElapsed;
        public void StartTimer(double interval)
        {
            m_Timer = new Timer(interval);
            m_Timer.Elapsed += TimerElapsed;
            m_Timer.Start();
        }
        public void StopTimer()
        {
            if (m_Timer != null)
            {
                m_Timer.Stop();
                m_Timer.Dispose();
            }
        }
        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnTimerElapsed?.Invoke();
        }
    }
}
