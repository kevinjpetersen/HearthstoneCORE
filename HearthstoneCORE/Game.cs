using HearthstoneCORE.Handlers;
using HearthstoneCORE.Objects.Components;
using HearthstoneCORE.Objects.Game;
using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE
{
    public class Game
    {
        public List<RenderComponent> RenderComponents;

        public UpdateHandler UpdateHandler { get; set; }
        public KeyboardHandler KeyboardHandler { get; set; }

        public ASCIIComponent Logo;
        public CardComponent Card;
        public GameBoardComponent GameBoard;

        public static Game Instance;

        public Game()
        {
            Instance = this;
            KeyboardHandler = new KeyboardHandler();

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

            HSCard testCard = new HSCard("Arthas the lich king", "At the start of your turn, gain +1 Amunkar Health which will disapear once you kill yourself", "TempArt", HSCard.Rarities.Legendary, 10, 22, 15, HSCard.CardTypes.Humanoid);


            Logo = new ASCIIComponent("logo", new RenderLocation(Console.WindowWidth - 5, 10));
            Card = new CardComponent(testCard, new RenderLocation(35, 6));
            GameBoard = new GameBoardComponent(new RenderLocation(1, 1));

            RenderComponents.Add(GameBoard);

            for(int i = 1; i <= 2; i++)
            {
                var c = new CardComponent(testCard, new RenderLocation(35 * i, 6));
                RenderComponents.Add(c);
            }

            RenderComponents.Add(Card);
            RenderComponents.Add(Logo);

        }

        public void LogicUpdate()
        {
            //Logo.Translate(new RenderLocation(1, 0));
            //Logo.Location = new RenderLocation(Console.WindowWidth / 2 - 30, 5);

            if(KeyboardHandler.GetKeyPress(ConsoleKey.D))
            {
                Logo.Translate(new RenderLocation(1, 0));
                UpdateHandler.Redraw();
            }

            if (KeyboardHandler.GetKeyPress(ConsoleKey.A))
            {
                Card.Translate(new RenderLocation(10, 0));
            }

            if(KeyboardHandler.GetKeyPress(ConsoleKey.Spacebar))
            {
                UpdateHandler.Redraw();
            }

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
