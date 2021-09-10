
namespace DesignPatterns.State.StateMachineStuff
{
    public abstract class BaseState<T>
    {
        public abstract void OnEnter(T t);
        public abstract void Update(T t, int deltaTimeMs);
    }
}
