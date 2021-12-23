namespace ConsoleApp3
{
    public abstract class Composite : Node
    {
        protected int _currentIndex = 0;

        public Composite(string name, Blackboard blackboard) : base(name, blackboard)
        {
        }

        protected Node GetChild()
        {
            return Children == null || _currentIndex >= Children.Count ? null : Children[_currentIndex];
        }

        protected void Next()
        {
            _currentIndex++;
        }

        protected bool IsLastChild()
        {
            return Children == null || _currentIndex == Children.Count - 1;
        }

        protected void Reset()
        {
            _currentIndex = 0;
        }
    }
}