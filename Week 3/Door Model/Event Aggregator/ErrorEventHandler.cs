using System;

namespace DoorEventAggregator
{
    public class ErrorEventHandler
    {
        public ErrorEventHandler()
        {
            EventAggregator.Instance.Subscribe<ErrorEventArgs>(PrintError);
        }
        public void PrintError(object eventArgs)
        {
            ErrorEventArgs errorEventArgs = eventArgs as ErrorEventArgs;
            if (errorEventArgs != null)
            {
                Console.WriteLine(errorEventArgs.ErrorMessage);
            }
        }
    }
}
