using DesignPatterns.Core;

namespace DesignPatterns.State
{
    public interface IEntity
    {
        DrawData Display { get; }
        Vector2 Position { get; }
    }
}