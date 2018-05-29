using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Game
{
    public class HSModifier
    {
        public bool Windfury;
        public bool Taunt;
        public bool Charge;
        public bool Stealth;

        public HSModifier(bool Windfury = false, bool Taunt = false, bool Charge = false, bool Stealth = false)
        {
            this.Windfury = Windfury;
            this.Taunt = Taunt;
            this.Charge = Charge;
            this.Stealth = Stealth;
        }
    }
}
