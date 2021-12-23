using System;

namespace ConsoleApp2
{
    public class MockPlayer
    {
        public string name;
        public Vector2 position;
        public bool hasKey;

        public MockPlayer(string name, Vector2 position, bool hasKey)
        {
            this.name = name;
            this.position = position;
            this.hasKey = hasKey;
        }

        public override string ToString()
        {
            return String.Format("Player [{0}] --- location: {1}, hasKye: {2}", name, position, hasKey);
        }
    }
}