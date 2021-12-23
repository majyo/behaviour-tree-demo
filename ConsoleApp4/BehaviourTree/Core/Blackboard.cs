using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Blackboard
    {
        private readonly Dictionary<string, object> _database;
        private const int InitCapacity = 16;

        public Blackboard()
        {
            _database = new Dictionary<string, object>(InitCapacity);
        }

        public void AddValue(string name, object value)
        {
            _database[name] = value;
        }

        public T RemoveValue<T>(string name)
        {
            if (_database.Remove(name, out object value))
            {
                return (T) value;
            }
            return default(T);
        }

        public T GetValue<T>(string name)
        {
            if (_database.TryGetValue(name, out object value))
            {
                return (T) value;
            }
            return default(T);
        }
    }
}