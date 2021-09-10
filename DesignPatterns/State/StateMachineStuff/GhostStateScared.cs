using System;

namespace DesignPatterns.State.StateMachineStuff
{
    public class GhostStateScared : BaseState<Ghost>
    {
        public override void OnEnter(Ghost ghost)
        {
            ghost.Display.Color = ConsoleColor.Cyan;
        }
        public override void Update(Ghost ghost, int deltaTimeMs)
        {
            ghost.MoveAwayFromPos(ghost.PacMan.Position, deltaTimeMs);

            if (!ghost.PacMan.IsEnergized)
            {
                ghost.MyStateMachine.ChangeState(Ghost.States.Chase, ghost);
            }

            if (ghost.Position == ghost.PacMan.Position)
            {
                ghost.MyStateMachine.ChangeState(Ghost.States.Dead, ghost);
            }
        }
    }
}
