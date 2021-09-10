using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State.StateMachineStuff
{
    public class GhostStateChase : BaseState<Ghost>
    {
        private const char DefaultChar = 'Ω';

        public override void OnEnter(Ghost ghost)
        {
            ghost.Display.Character = DefaultChar;

            ghost.Display.Color = ConsoleColor.Magenta;
        }
        public override void Update(Ghost ghost, int deltaTimeMs)
        {
            ghost.MoveTowardsPos(ghost.PacMan.Position, deltaTimeMs);

            if (ghost.PacMan.IsEnergized)
            {
                ghost.MyStateMachine.ChangeState(Ghost.States.Scared, ghost);
            }
        }
    }
}
