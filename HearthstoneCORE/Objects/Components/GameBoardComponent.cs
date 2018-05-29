using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Components
{
    public class GameBoardComponent : RenderComponent
    {
        public GameBoardComponent(RenderLocation Location) : base(Location)
        {
            
        }

        public override void Render()
        {
            RenderBox(Location, new RenderSize(Console.WindowWidth - 3, Console.WindowHeight - 3));
            RenderAsciiFile("player_base", new RenderLocation(Console.WindowWidth / 2 - 15, 1));
            RenderAsciiFile("player_base", new RenderLocation(Console.WindowWidth / 2 - 15, Console.WindowHeight - 7));
        }
    }
}
