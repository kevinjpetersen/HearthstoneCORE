using HearthstoneCORE.Objects.Game;
using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Components
{
    public class CardComponent : RenderComponent
    {
        public HSCard Card { get; set; }

        public CardComponent(HSCard Card, RenderLocation Location) : base(Location)
        {
            this.Card = Card;
        }

        public override void Render()
        {
            RenderAsciiFile("card", Location);
            RenderText(Card.ManaCost.ToString(), new RenderLocation(Location.X + 2, Location.Y + 1), foregroundColor: ConsoleColor.Blue);
            RenderText(Card.Attack.ToString(), new RenderLocation(Location.X + 2, Location.Y + 19), foregroundColor: ConsoleColor.Yellow);
            RenderText(Card.Health.ToString(), new RenderLocation(Location.X + 28, Location.Y + 19), foregroundColor: ConsoleColor.Red);
            RenderText(Card.Name, new RenderLocation(Location.X + 1, Location.Y + 10), new RenderSize(31, 1), textHorizontalAlignment: Alignment.Center, foregroundColor: ConsoleColor.White);
            RenderText(Card.Description, new RenderLocation(Location.X + 2, Location.Y + 11), 28, 0, foregroundColor: ConsoleColor.White);
            RenderCardImageArtAsciiFile(Card.ImageArtFileName, new RenderLocation(Location.X + 1, Location.Y + 1));
        }
    }
}
