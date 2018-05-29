using HearthstoneCORE.Components;
using HearthstoneCORE.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE
{
    public class Game
    {
        public UpdateHandler UpdateHandler { get; set; }
        public List<RenderComponent> RenderComponents;

        public ASCIIComponent Logo;
        public ASCIIComponent Card;

        public Game()
        {
            Init();
            UpdateHandler = new UpdateHandler(LogicUpdate, DrawUpdate);
            UpdateHandler.Handle();
        }
        
        public void Init()
        {
            Console.Title = "HearthstoneCORE";
            Console.CursorVisible = false;
            
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            RenderComponents = new List<RenderComponent>();

            Logo = new ASCIIComponent("logo", new RenderLocation(Console.BufferWidth / 2 - 30, 0));
            Card = new ASCIIComponent("card", new RenderLocation(35, 4));

            RenderComponents.Add(Logo);
            RenderComponents.Add(Card);

        }

        public void LogicUpdate()
        {

            //Logo.Translate(new RenderLocation(1, 0));
        }

        public void DrawUpdate()
        {
            foreach(var rc in RenderComponents)
            {
                rc.Render();
            }

        }
    }
}
