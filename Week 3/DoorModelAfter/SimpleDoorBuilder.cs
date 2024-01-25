namespace DoorPrototypeImproved
{
    public class SimpleDoorBuilder
    {
        public SimpleDoor BuildSimpleDoor()
        {
            SimpleDoor door = new SimpleDoor();
            DoorOperationErrorNotifier errorNotifier = new DoorOperationErrorNotifier();
            door.OnErrorNotify += new System.Action<string>(errorNotifier.Notify);
            return door;
        }
    }
}
