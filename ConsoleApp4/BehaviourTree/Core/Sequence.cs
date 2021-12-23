namespace ConsoleApp3
{
    public class Sequence : Composite
    {
        public Sequence(string name, Blackboard blackboard) : base(name, blackboard)
        {
        }
        public override bool OnEvaluated()
        {
            return true;
        }

        public override NodeStatus OnTicked()
        {
            Node child = GetChild();
            
            if (child == null)
            {
                return NodeStatus.Success;
            }

            NodeStatus status = child.Tick();

            if (status == NodeStatus.Failure)
            {
                Reset();
                return NodeStatus.Failure;
            }

            if (status == NodeStatus.Running)
            {
                return NodeStatus.Running;
            }

            if (IsLastChild())
            {
                Reset();
                return NodeStatus.Success;
            }

            Next();
            return NodeStatus.Running;
        }
    }
}