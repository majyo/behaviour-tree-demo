using System;

namespace ConsoleApp2
{
    public enum DoorStatus
    {
        Opened,
        Closed,
        Locked
    }
    
    public class MockDoor
    {
        public string name;
        public DoorStatus status;
        public Vector2 position;

        public MockDoor(string name, DoorStatus status, Vector2 position)
        {
            this.name = name;
            this.status = status;
            this.position = position;
        }

        public override string ToString()
        {
            // string[] map = new[] { "Opened", "Closed", "Locked" };
            return String.Format("Door [{0}] --- location: {1}, status: {2}", name, position, status);
        }
    }
}