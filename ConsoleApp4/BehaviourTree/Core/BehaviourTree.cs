namespace ConsoleApp3
{
    public class BehaviourTree
    {
        private Node _root;

        public BehaviourTree(Node root)
        {
            _root = root;
        }

        public void OnUpdate()
        {
            _root.Tick();
        }
    }
}