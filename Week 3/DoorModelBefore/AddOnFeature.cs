using System;

namespace DoorPrototype
{
    public abstract class AddOnFeature
    {
        public abstract void ExecuteAction();
    }
    public class BuzzerAlertFeature : AddOnFeature
    {
        public override void ExecuteAction()
        {
            Console.WriteLine("BUZZER ALERT");
        }
    }
    public class PagerAlertFeature : AddOnFeature
    {
        public override void ExecuteAction()
        {
            Console.WriteLine("PAGER ALERT");
        }
    }
    public class AutoCloseFeature : AddOnFeature
    {
        readonly IDoor doorOperator;
        public AutoCloseFeature(IDoor doorOperator)
        {
            this.doorOperator = doorOperator;
        }
        public override void ExecuteAction()
        {
            doorOperator.Close();
            Console.WriteLine("Smart Door automatically closed");
        }
    }
}
