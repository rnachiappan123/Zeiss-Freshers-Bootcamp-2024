using System;

namespace DoorEventAggregator
{
    public class ErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
        public ErrorEventArgs(string message)
        {
            ErrorMessage = message;
        }
    }
    public class DoorOpenEventArgs : EventArgs
    {
        public double TimeLimit { get; set; }
        public DoorOpenEventArgs(double timeLimit)
        {
            TimeLimit = timeLimit;
        }
    }
    public class DoorCloseEventArgs : EventArgs { }
    public class TimerElapsedEventArgs : EventArgs { }
    public class DoorOpenAlertEventArgs : EventArgs { }
}
