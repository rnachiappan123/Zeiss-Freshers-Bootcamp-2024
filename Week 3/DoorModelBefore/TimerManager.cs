using System;
using System.Timers;

namespace DoorPrototype
{
    public class TimerManager
    {
        Timer m_Timer;
        public static event Action OnTimerElapsed;
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
        static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnTimerElapsed?.Invoke();
        }
    }
}
