using System;
using System.Threading;

namespace ConsoleApp2
{
    public class MockGameEngine
    {
        public double currentTime;
        public GameManager gameManager;
        public double deltTime = 0.5;

        public void Init()
        {
            gameManager = new GameManager();
        }
        
        public void GameLoop()
        {
            gameManager.Start();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine(String.Format("Current time: {0,10:F3}", currentTime));
                
                gameManager.Update();

                currentTime += deltTime;
                Thread.Sleep(TimeSpan.FromSeconds(deltTime));
            }
        }
    }
}