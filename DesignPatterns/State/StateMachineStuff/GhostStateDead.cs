using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State.StateMachineStuff
{
    public class GhostStateDead : BaseState
    {
        private const char DeadChar = '%';

        public override void OnEnter(Ghost ghost)
        {
            ghost.Display.Character = DeadChar;
        }
        public override void Update(Ghost ghost, int deltaTimeMs)
        {
            ghost.MoveTowardsPos(World.GhostHome, deltaTimeMs);

            if(ghost.Position == World.GhostHome)
            {
                ghost.MyStateMachine.ChangeState(StateMachine.States.Chase, ghost);
            }
        }
    }
}
