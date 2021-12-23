using System;
using ConsoleApp3;

namespace ConsoleApp2
{
    public class GameManager
    {
        private MockPlayer _player;
        private MockDoor _door;
        private PlayerBT _playerBehaviour;

        public void Start()
        {
            _player = new MockPlayer("Player 1", new Vector2(0.0f, 0.0f), true);
            _door = new MockDoor("Door 1", DoorStatus.Locked, new Vector2(5.0f, 10.0f));
            _playerBehaviour = PlayerBT.Create(_player, _door);
        }

        public void Update()
        {
            _playerBehaviour.OnUpdate();
            Console.WriteLine(_player);
            Console.WriteLine(_door);
        }
    }
}