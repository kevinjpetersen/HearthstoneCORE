using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Game
{
    public class HSGame
    {
        public HSPlayer Player1 { get; set; }
        public HSPlayer Player2 { get; set; }

        public List<HSCard> CardsOnBattlefield { get; set; }
        
    }
}
