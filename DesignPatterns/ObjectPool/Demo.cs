using System;
using DesignPatterns.State;

namespace DesignPatterns.ObjectPool
{
    public class Demo
    {
        private static DateTime _lastUpdate;

        public static void Run()
        {
            Screen screen = new Screen();

            _lastUpdate = DateTime.Now; // Initialize this here, otherwise we get a crazy delta time on first update loop iteration.
            while (!ParticleMgr.Instance.IsFinished)
            {
                DateTime now = DateTime.Now;
                int deltaTimeMs = (int)(now - _lastUpdate).TotalMilliseconds;
                _lastUpdate = now;

                ParticleMgr.Instance.Update(deltaTimeMs);
                screen.Draw();
            }
        }
    }
}