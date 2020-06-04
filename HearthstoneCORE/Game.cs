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
        public GameBoardComponent GameBoard;

        public static Game Instance;

        public HSPlayer player1;

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


            List<HSCard> cards = HSCard.GetAllCards();

            HSDeck deck = new HSDeck();
            deck.AddCards(cards);

            player1 = new HSPlayer(deck);

            Logo = new ASCIIComponent("logo", new RenderLocation(Console.WindowWidth - 5, 10));

            GameBoard = new GameBoardComponent(new RenderLocation(1, 1));

            RenderComponents.Add(GameBoard);

            //int i = 1;
            //foreach(var card in deck.Cards)
            //{
            //    card.RenderComponent = new CardComponent(card, new RenderLocation(i * 5, 6));
            //    RenderComponents.Add(card.RenderComponent);
            //    i++;
            //}

            RenderComponents.Add(Logo);

            SoundHandler.Instance.PlaySound(Environment.CurrentDirectory + "/Resources/Audio/aa.wav");

        }

        public void LogicUpdate()
        {
            //Logo.Translate(new RenderLocation(1, 0));
            //Logo.Location = new RenderLocation(Console.WindowWidth / 2 - 30, 5);

            if(KeyboardHandler.GetKeyPress(ConsoleKey.F))
            {
                //player1.HighlightCard(player1.CardsInHand[0]);
                player1.GoThroughHand();
                UpdateHandler.Redraw();
            }

            if (KeyboardHandler.GetKeyPress(ConsoleKey.G))
            {
                player1.UnhighlightCard(player1.HighlightedCard);
                UpdateHandler.Redraw();
            }

            if (KeyboardHandler.GetKeyPress(ConsoleKey.Spacebar))
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

            int i = 1;
            foreach(var rc in player1.CardsInHand)
            {
                if(player1.HighlightedCard != rc)
                {
                    rc.RenderComponent.Location = new RenderLocation(Console.WindowWidth / 2 - (i * 5), Console.WindowHeight - 28);
                } else
                {
                    rc.RenderComponent.Location = new RenderLocation(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 15);
                }
                rc.RenderComponent.Render();
                i++;
            }

        }
    }
}
