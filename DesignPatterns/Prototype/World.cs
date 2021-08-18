using System.Collections.Generic;

namespace DesignPatterns.Prototype
{
    public class World
    {
        private readonly List<Monster> _monsters = new List<Monster>();
        //private MonsterSpawner _spawner = new MonsterSpawner(0, 0);

        public World()
        {
            
        }

        public void Tick()
        {
            if (_monsters.Count == 0) // Only spawn if no monsters are left.
            {
                
            }
        }

        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
        }
    }
}