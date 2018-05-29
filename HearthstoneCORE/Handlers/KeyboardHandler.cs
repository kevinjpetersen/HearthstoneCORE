using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Handlers
{
    public class KeyboardHandler
    {
        public enum KeyPressed
        {
            None, W, A, S, D, One, Two, Three
        }

        public KeyPressed CurrentKeyPressed = KeyPressed.None;

        public KeyboardHandler()
        {
            CurrentKeyPressed = KeyPressed.None;
        }

        public void Reset()
        {
            CurrentKeyPressed = KeyPressed.None;
        }

        public bool GetKeyPress(KeyPressed keypress)
        {
            KeyPressed kp = CurrentKeyPressed;
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

            switch (cki.KeyChar)
            {
                case 'w':
                    CurrentKeyPressed = KeyPressed.W;
                    break;
                case 'a':
                    CurrentKeyPressed = KeyPressed.A;
                    break;
                case 's':
                    CurrentKeyPressed = KeyPressed.S;
                    break;
                case 'd':
                    CurrentKeyPressed = KeyPressed.D;
                    break;
                case '1':
                    CurrentKeyPressed = KeyPressed.One;
                    break;
                case '2':
                    CurrentKeyPressed = KeyPressed.Two;
                    break;
                case '3':
                    CurrentKeyPressed = KeyPressed.Three;
                    break;
            }
        }
    }
}
