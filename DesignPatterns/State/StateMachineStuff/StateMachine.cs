using System.Collections.Generic;

namespace DesignPatterns.State.StateMachineStuff
{
    public class StateMachine<TEntity, TEnum>
    {
        public BaseState<TEntity> CurrentState { get; set; }

        public StateMachine(TEnum initState, TEntity tEntity)
        {
            ChangeState(initState, tEntity);
        }

        private Dictionary<TEnum, BaseState<TEntity>> StateDictionary = new Dictionary<TEnum, BaseState<TEntity>>
        {
            
        };

        public void ChangeState(TEnum state, TEntity tEntity)
        {
            CurrentState = StateDictionary[state];

            CurrentState.OnEnter(tEntity);
        }
    }
}
