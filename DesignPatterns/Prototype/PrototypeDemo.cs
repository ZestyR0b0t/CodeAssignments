namespace DesignPatterns.Prototype
{
    public class PrototypeDemo
    {
        public static void Run()
        {
            World gameWorld = new World();

            gameWorld.Tick(); // Pretend this is in a game loop getting called every frame.
        }
    }
}