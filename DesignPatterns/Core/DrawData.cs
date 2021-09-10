using System;

namespace DesignPatterns.Core
{
    public class DrawData
    {
        public Vector2 PreviousPosition { get; set; }
        public ConsoleColor Color { get; set; }
        public char Character { get; set; }

        public DrawData()
        {

        }
        public DrawData(ConsoleColor color, char character)
        {
            Color = color;
            Character = character;
        }
    }
}