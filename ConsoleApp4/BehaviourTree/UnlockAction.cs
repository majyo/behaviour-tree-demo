using ConsoleApp2;

namespace ConsoleApp3;

public class UnlockAction : Action
{
    private MockPlayer _player;
    private MockDoor _door;

    public UnlockAction(string name, Blackboard blackboard) : base(name, blackboard)
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

        if (_door.status != DoorStatus.Locked)
        {
            Console.WriteLine(string.Format("Door [{0}] is not locked. There is no need to unlock.", _door.name));
            return NodeStatus.Success;
        }

        if (!_player.hasKey)
        {
            Console.WriteLine(string.Format("Player [{0}] has no key.", _player.name));
            return NodeStatus.Failure;
        }

        Console.WriteLine(string.Format("Door [{0}] is unlocked.", _door.name));
        _door.status = DoorStatus.Closed;
        return NodeStatus.Success;
    }
}