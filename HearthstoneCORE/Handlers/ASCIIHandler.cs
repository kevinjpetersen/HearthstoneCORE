using HearthstoneCORE.Objects;
using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HearthstoneCORE.Handlers
{
    public class ASCIIHandler
    {
        private const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        private const ConsoleColor DefaultForegroundColor = ConsoleColor.White;

        public enum Alignment
        {
            Left, Center, Right
        }

        public void RenderText(string text, RenderLocation Location, ConsoleColor backgroundColor = DefaultBackgroundColor, ConsoleColor foregroundColor = DefaultForegroundColor)
        {
            SetPosition(Location);
            ChangeColors(backgroundColor, foregroundColor);

            Console.Write(text);

            ChangeColors();
        }

        public void RenderText(string text, RenderLocation Location, RenderSize Size, ConsoleColor backgroundColor = DefaultBackgroundColor, ConsoleColor foregroundColor = DefaultForegroundColor, Alignment textHorizontalAlignment = Alignment.Left)
        {
            switch(textHorizontalAlignment)
            {
                case Alignment.Left:
                    SetPosition(new RenderLocation(Location.X, Location.Y));
                    break;
                case Alignment.Center:
                    SetPosition(new RenderLocation(Location.X + Size.Width / 2 - text.Length / 2, Location.Y));
                    break;
                case Alignment.Right:
                    SetPosition(new RenderLocation(Location.X + Size.Width - text.Length - 1, Location.Y));
                    break;
            }

            ChangeColors(backgroundColor, foregroundColor);

            Console.Write(text);

            ChangeColors();
        }

        public void RenderText(string text, RenderLocation Location, int maxWidth, int maxHeight, ConsoleColor backgroundColor = DefaultBackgroundColor, ConsoleColor foregroundColor = DefaultForegroundColor)
        {
            SetPosition(Location);
            ChangeColors(backgroundColor, foregroundColor);

            int y = 0;
            int x = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i % maxWidth == 0)
                {
                    y++;
                    x = 0;
                }
                SetPosition(new RenderLocation(Location.X + x, Location.Y + y));
                Console.Write(text[i]);
                x++;
            }

            ChangeColors();
        }

        public void RenderAsciiFile(string filename, RenderLocation Location)
        {
            string[] asciiLines = File.ReadAllLines(string.Format(Environment.CurrentDirectory + "/Resources/ASCII/{0}.ascii", filename));

            int y = Location.Y;

            foreach (string line in asciiLines)
            {
                SetPosition(Location.X, y);
                Console.Write(line);
                y++;
            }
        }

        public void RenderCardImageArtAsciiFile(string filename, RenderLocation Location)
        {
            string[] asciiLines = File.ReadAllLines(string.Format(Environment.CurrentDirectory + "/Resources/CardsImageArt/{0}.ascii", filename));

            int y = Location.Y;

            foreach (string line in asciiLines)
            {
                SetPosition(Location.X, y);
                Console.Write(line);
                y++;
            }
        }

        public void RenderBox(RenderLocation Location, RenderSize Size)
        {
            string s = "╔";
            string space = "";
            string temp = "";
            for (int i = Location.X; i < Size.Width; i++)
            {
                space += " ";
                s += "═";
            }

            for (int j = 0; j < Location.X; j++)
                temp += " ";

            s += "╗" + "\n";

            for (int i = Location.Y; i < Size.Height; i++)
                s += temp + "║" + space + "║" + "\n";

            s += temp + "╚";
            for (int i = 0; i < Size.Width - 1; i++)
                s += "═";

            s += "╝" + "\n";
            
            Console.CursorTop = Location.Y;
            Console.CursorLeft = Location.X;
            Console.Write(s);


            //for(int x = Location.X; x < Size.Width; x++)
            //{
            //    for (int y = Location.Y; y < Size.Height; y++)
            //    {
            //        SetPosition(x, y);
            //        if (y == Location.Y && x == Location.X) Console.Write("╔");
            //        else if (y == Size.Height - 1 && x == Location.X) Console.Write("╚");
            //        else if (y == Location.Y && x == Size.Width - 1) Console.Write("╗");
            //        else if (y == Size.Height - 1 && x == Size.Width - 1) Console.Write("╝");
            //        else if (y == Location.Y || y == Size.Height - 1) Console.Write("═");
            //        else if (x == Location.X || x == Size.Width - 1) Console.Write("║");
            //    }
            //}
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
