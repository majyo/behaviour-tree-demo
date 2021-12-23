using ConsoleApp2;

namespace ConsoleApp3;

public class OpenDoorAction : Action
{
    private MockPlayer _player;
    private MockDoor _door;

    public OpenDoorAction(string name, Blackboard blackboard) : base(name, blackboard)
    {
        _player = blackboard.GetValue<MockPlayer>("Player 1");
        _door = blackboard.GetValue<MockDoor>("Door 1");
    }

    public override bool OnEvaluated()
    {
        return true;
    }

    public override NodeStatus OnTicked()
    {
        if ((_door.position - _player.position).Norm() > 1.0f)
        {
            Console.WriteLine(string.Format("Door [{0}] is too far away.", _door.name));
            return NodeStatus.Failure;
        }

        if (_door.status == DoorStatus.Locked)
        {
            Console.WriteLine(string.Format("Door [{0}] is locked.", _door.name));
            return NodeStatus.Failure;
        }

        Console.WriteLine(string.Format("Door [{0}] is opened by Player [{1}].", _door.name, _player.name));
        _door.status = DoorStatus.Opened;
        return NodeStatus.Success;
    }
}