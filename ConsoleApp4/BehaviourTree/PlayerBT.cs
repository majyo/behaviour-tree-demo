using ConsoleApp2;

namespace ConsoleApp3
{
    public class PlayerBT : BehaviourTree
    {
        public PlayerBT(Node root) : base(root)
        {
        }

        public static PlayerBT Create(MockPlayer player, MockDoor door)
        {
            var blackboard = new Blackboard();
            blackboard.AddValue("Player 1", player);
            blackboard.AddValue("Door 1", door);
            
            var root = new Sequence("OpenDoor Sequence", blackboard);
            var child1 = new WalkToAction("WalkTo Action", blackboard, door.position);
            var child2 = new Selector("OpenDoor Selector", blackboard);
            var child3 = new OpenDoorAction("OpenDoor Action", blackboard);
            var child4 = new UnlockAction("UnlockDoor Action", blackboard);

            root.AddChild(child1);
            root.AddChild(child2);
            child2.AddChild(child3);
            child2.AddChild(child4);

            return new PlayerBT(root);
        }
    }
}