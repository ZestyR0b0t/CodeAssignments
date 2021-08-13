using System.Collections.Generic;

namespace DesignPatterns.Prototype
{
    public class World
    {
        private readonly List<Monster> _monsters = new List<Monster>();

        public World()
        {

        }

        public void Tick()
        {
            if (_monsters.Count == 0) // Only spawn if no monsters are left.
            {
                // TODO: Spawn 2 ghosts *using a spawner*
                // TODO: Spawn 2 demons *using a spawner*
            }
        }

        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
        }
    }
}