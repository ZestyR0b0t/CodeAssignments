using System;

namespace DesignPatterns.Prototype
{
    public class MonsterSpawner
    {
        private int _x;
        private int _y;
        private Monster _monsterTemplate;

        public MonsterSpawner(int x, int y, Monster monster)
        {
            _x = x;
            _y = y;
            _monsterTemplate = monster;
        }

        public void SpawnMonster(World world)
        {
            var clone = _monsterTemplate.Clone();

            clone.SetPosition(_x, _y);

            world.AddMonster(clone);
        }
    }
}