namespace DoorPrototypeImproved
{
    public class AutoCloseDoor : AddOnFeature
    {
        readonly ISmartDoorClose smartDoorClose;
        public AutoCloseDoor(ISmartDoorClose smartDoor)
        {
            smartDoorClose = smartDoor;
        }
        public override void ExecuteAction()
        {
            smartDoorClose?.Close();
        }
    }
}
