using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HearthstoneCORE.Components
{
    public class UpdateHandler
    {
        private const int frameRate = 1000 / 5; // Rethink this
        private bool isRendering = true;
        private Thread renderingThread;

        public delegate void LogicUpdate_Function();
        public delegate void DrawUpdate_Function();

        private LogicUpdate_Function logicUpdate;
        private DrawUpdate_Function drawUpdate;

        public UpdateHandler(LogicUpdate_Function LogicUpdate, DrawUpdate_Function DrawUpdate)
        {
            logicUpdate = LogicUpdate;
            drawUpdate = DrawUpdate;
        }

        public void Handle()
        {
            renderingThread = new Thread(() =>
            {
                while (isRendering)
                {
                    Console.Clear();

                    logicUpdate();
                    drawUpdate();

                    Thread.Sleep(frameRate);
                }
            });
            renderingThread.IsBackground = true;
            renderingThread.Start();
        }


    }
}
