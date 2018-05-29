using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Utilities
{
    public class RenderLocation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public RenderLocation(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
