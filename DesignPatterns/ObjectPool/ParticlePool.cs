using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ObjectPool
{
    public class ParticlePool
    {
        private int _maxCapacity { get; set; }

        // Collection of premade objects 
        // Thing that tracks whether objex are in use or not 

        private List<Particle> _particleList;
        private List<int> _particlesInUse;

        public ParticlePool (int sizeOfPool)
        {
            _particleList = new List<Particle>(sizeOfPool);

            _particlesInUse = new List<int>(sizeOfPool);

            for (int i = 0; i < sizeOfPool; i++)
            {
                _particleList.Add(new Particle());
            }
        }

        public Particle GetAParticle()
        {
            for (int i = 0; i < _particleList.Count; i++)
            {
                if (!_particlesInUse.Contains(i))
                {
                    _particlesInUse.Add(i);

                    return _particleList[i];
                }
            }

            return null;
        }

        public void ReturnParticleToPool(Particle particle)
        {
            int index = _particleList.IndexOf(particle);

            if (_particlesInUse.Contains(index))
            {
                _particlesInUse.Remove(index);
            }
        }
    }
}
