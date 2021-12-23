using System;
using ConsoleApp2;

namespace ConsoleApp3
{
    public class WalkToAction : Action
    {
        private MockPlayer _player;
        private Vector2 _destination;

        public WalkToAction(string name, Blackboard blackboard, Vector2 destination) : base(name, blackboard)
        {
            _player = Blackboard.GetValue<MockPlayer>("Player 1");
            SetDestination(destination);
        }

        public void SetDestination(Vector2 destination)
        {
            _destination = destination;
        }
        
        public override bool OnEvaluated()
        {
            return true;
        }

        public override NodeStatus OnTicked()
        {
            if (DestinationReached())
            {
                Console.WriteLine(String.Format("Player [{0}] reached destination.", _player.name));
                return NodeStatus.Success;
            }
            
            Move();
            Console.WriteLine(String.Format("Player [{0}] is moving.", _player.name));
            return NodeStatus.Running;
        }

        public void Move(float step=0.5f)
        {
            Vector2 moveDirection = (_destination - _player.position).Normalized();
            _player.position = _player.position + moveDirection * step;
        }

        public bool DestinationReached()
        {
            return (_player.position - _destination).Norm() < 1.0f;
        }
    }
}