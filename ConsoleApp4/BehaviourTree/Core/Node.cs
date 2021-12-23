using System.Collections.Generic;

namespace ConsoleApp3
{
    public enum NodeStatus
    {
        Success,
        Failure,
        Running,
        UnActive
    }
    
    public abstract class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; set; }
        public Blackboard Blackboard { get; set; }
        public bool IsActive { get; set; }

        public Node(string name, Blackboard blackboard)
        {
            this.Name = name;
            this.Blackboard = blackboard;
        }

        public virtual void OnAdded()
        {
        }

        public virtual void OnRemoved()
        {
        }

        public abstract bool OnEvaluated();

        public abstract NodeStatus OnTicked();

        public bool Evaluate()
        {
            return OnEvaluated();
        }

        public NodeStatus Tick()
        {
            if (!Evaluate())
            {
                return NodeStatus.Failure;
            }
            
            return OnTicked();
        }

        public virtual void AddChild(Node node)
        {
            Children ??= new List<Node>();
            
            Children.Add(node);
            node.OnAdded();
        }

        public virtual void RemoveChild(Node node)
        {
            node = null;
            if (node == null)
            {
                return;
            }

            bool isSucceed = Children.Remove(node);

            if (isSucceed)
            {
                node.OnRemoved();
            }
        }
    }
}