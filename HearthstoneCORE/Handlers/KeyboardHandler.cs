using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Handlers
{
    public class KeyboardHandler
    {
        public ConsoleKey CurrentKeyPressed = ConsoleKey.NoName;

        public KeyboardHandler()
        {
            CurrentKeyPressed = ConsoleKey.NoName;
        }

        public void Reset()
        {
            CurrentKeyPressed = ConsoleKey.NoName;
        }

        public bool GetKeyPress(ConsoleKey keypress)
        {
            ConsoleKey kp = CurrentKeyPressed;
            if (kp == keypress)
            {
                Reset();
                return true;
            }
            return false;
        }

        public void Events()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            CurrentKeyPressed = cki.Key;
        }
    }
}
