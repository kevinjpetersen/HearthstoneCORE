using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HearthstoneCORE.Handlers
{
    public class UpdateHandler
    {
        private const int FPS = 30;
        private bool isRunning = true;
        private Thread keyboardThread;
        private bool redraw = true;

        public delegate void LogicUpdate_Function();
        public delegate void DrawUpdate_Function();

        private LogicUpdate_Function logicUpdate;
        private DrawUpdate_Function drawUpdate;

        public UpdateHandler(LogicUpdate_Function LogicUpdate, DrawUpdate_Function DrawUpdate)
        {
            logicUpdate = LogicUpdate;
            drawUpdate = DrawUpdate;
        }

        public void Redraw()
        {
            redraw = true;
        }

        public void Handle()
        {
            keyboardThread = new Thread(() =>
            {
                while (isRunning)
                {
                    Game.Instance.KeyboardHandler.Events();
                    Thread.Sleep(1000 / FPS);
                }
            });
            keyboardThread.IsBackground = true;
            keyboardThread.Start();

            while (isRunning)
            {

                logicUpdate();

                if(redraw)
                {
                    redraw = false;
                    Console.Clear();
                    drawUpdate();
                }

                Thread.Sleep(1000 / FPS);
            }
        }


    }
}
