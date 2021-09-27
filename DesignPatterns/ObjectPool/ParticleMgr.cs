using System;
using System.Collections.Generic;

namespace DesignPatterns.ObjectPool
{
    public class ParticleMgr
    {
        #region Singleton

        private static readonly Lazy<ParticleMgr> _instance = new Lazy<ParticleMgr>(() => new ParticleMgr());
        public static ParticleMgr Instance => _instance.Value;
        private ParticleMgr() { }

        #endregion

        private const int TotalSpawns = 50;
        private const int MsBetweenSpawns = 200;

        private int _spawnCount = 0;
        private int _msSinceLastSpawn = 0;
        private readonly ISet<Particle> _pendingRemoval = new HashSet<Particle>();

        private ParticlePool _particlePool = new ParticlePool(1); 

        public ISet<Particle> Particles { get; } = new HashSet<Particle>();

        public bool IsFinished { get; private set; }

        public void Update(int deltaTimeMs)
        {
            // Clear out dead particles
            HandleDeadParticles();

            if (IsFinished)
            {
                return;
            }

            if (_spawnCount >= TotalSpawns && Particles.Count == 0)
            {
                IsFinished = true;
                return;
            }

            foreach (Particle particle in Particles)
            {
                particle.Update(deltaTimeMs);
            }

            HandleSpawns(deltaTimeMs);
        }

        public void MarkForRemoval(Particle toRemove)
        {
            _pendingRemoval.Add(toRemove);
        }

        private void HandleDeadParticles()
        {
            // Clear out dead particles
            if (_pendingRemoval.Count > 0)
            {
                foreach (Particle particle in _pendingRemoval)
                {
                    Particles.Remove(particle);

                    particle.Reset();

                    _particlePool.ReturnParticleToPool(particle);
                }

                _pendingRemoval.Clear();
            }
        }

        private void HandleSpawns(int deltaTimeMs)
        {
            if (_spawnCount >= TotalSpawns)
            {
                return;
            }

            _msSinceLastSpawn += deltaTimeMs;
            if (_msSinceLastSpawn < MsBetweenSpawns)
            {
                return; // Too early to spawn
            }

            Particle particle = _particlePool.GetAParticle();
            
            if (particle == null)
            {
                return;
            }

            Particles.Add(particle);
            _msSinceLastSpawn = 0;
            _spawnCount++;
        }
    }
}