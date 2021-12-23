namespace ConsoleApp3
{
    public class Selector : Composite
    {
        public Selector(string name, Blackboard blackboard) : base(name, blackboard)
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
                return NodeStatus.Failure;
            }

            NodeStatus status = child.Tick();

            if (status == NodeStatus.Success)
            {
                Reset();
                return NodeStatus.Success;
            }

            if (status == NodeStatus.Running)
            {
                return NodeStatus.Running;
            }

            if (IsLastChild())
            {
                Reset();
                return NodeStatus.Failure;
            }

            Next();
            return NodeStatus.Running;
        }
    }
}