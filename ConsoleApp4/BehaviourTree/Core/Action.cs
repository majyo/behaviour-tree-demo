using System;

namespace ConsoleApp3
{
    public abstract class Action : Node
    {
        public Action(string name, Blackboard blackboard) : base(name, blackboard)
        {
        }
        
        public override void AddChild(Node node)
        {
            throw new ApplicationException("Action node has no child.");
        }

        public override void RemoveChild(Node node)
        {
            throw new ApplicationException("Action node has no child.");
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}