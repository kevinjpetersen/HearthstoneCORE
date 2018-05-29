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
            RenderText((Card.mana.HasValue ? Card.mana.Value.ToString() : "0"), new RenderLocation(Location.X + 2, Location.Y + 1), foregroundColor: ConsoleColor.Blue);
            RenderText((Card.attack.HasValue ? Card.attack.Value.ToString() : "0"), new RenderLocation(Location.X + 2, Location.Y + 19), foregroundColor: ConsoleColor.Yellow);
            RenderText((Card.health.HasValue ? Card.health.Value.ToString() : "0"), new RenderLocation(Location.X + 28, Location.Y + 19), foregroundColor: ConsoleColor.Red);
            RenderText(Card.name, new RenderLocation(Location.X + 1, Location.Y + 10), new RenderSize(31, 1), textHorizontalAlignment: Alignment.Center, foregroundColor: ConsoleColor.White);
            RenderText(Card.description, new RenderLocation(Location.X + 2, Location.Y + 11), 28, 0, foregroundColor: ConsoleColor.White);
            RenderCardImageArtAsciiFile("TempArt", new RenderLocation(Location.X + 1, Location.Y + 1));
        }
    }
}
