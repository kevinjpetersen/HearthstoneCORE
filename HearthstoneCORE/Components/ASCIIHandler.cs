using HearthstoneCORE.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HearthstoneCORE.Components
{
    public class ASCIIHandler
    {
        private const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        private const ConsoleColor DefaultForegroundColor = ConsoleColor.White;

        public void RenderText(string text, RenderLocation Location, ConsoleColor backgroundColor = DefaultBackgroundColor, ConsoleColor foregroundColor = DefaultForegroundColor)
        {
            SetPosition(Location);
            ChangeColors(backgroundColor, foregroundColor);

            Console.Write(text);

            ChangeColors();
        }

        public void RenderAsciiFile(string filename, RenderLocation Location)
        {
            string[] asciiLines = File.ReadAllLines(string.Format(Environment.CurrentDirectory + "/Graphic/{0}.ascii", filename));

            int y = Location.Y;

            foreach (string line in asciiLines)
            {
                SetPosition(Location.X, y);
                Console.Write(line);
                y++;
            }
        }

        public void SetPosition(RenderLocation Location)
        {
            Console.SetCursorPosition(Location.X, Location.Y);
        }

        public void SetPosition(int X, int Y)
        {
            int bw = Console.BufferWidth;
            int bh = Console.BufferWidth;

            if (X >= bw) X = bw - 1;
            if (Y >= bh) Y = bh - 1;
            Console.SetCursorPosition(X, Y);
        }

        private void ChangeColors(ConsoleColor backgroundColor = DefaultBackgroundColor, ConsoleColor foregroundColor = DefaultForegroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}
