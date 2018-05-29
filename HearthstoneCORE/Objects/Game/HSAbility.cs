using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Game
{
    public class HSAbility
    {
        public bool Battlecry;
        public bool Deathrattle;
        public bool Inspire;

        public HSAbility(bool Battlecry = false, bool Deathrattle = false, bool Inspire = false)
        {
            this.Battlecry = Battlecry;
            this.Deathrattle = Deathrattle;
            this.Inspire = Inspire;
        }
    }
}
