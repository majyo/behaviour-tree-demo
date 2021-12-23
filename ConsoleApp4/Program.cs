using System;
using ConsoleApp2;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            MockGameEngine gameEngine = new MockGameEngine();
            
            gameEngine.Init();
            gameEngine.GameLoop();
        }
    }
}