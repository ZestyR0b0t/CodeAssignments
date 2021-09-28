namespace DesignPatterns.Core
{
    public interface IEntity
    {
        DrawData Display { get; }
        Vector2 Position { get; }
        bool IsDead { get; }
    }
}