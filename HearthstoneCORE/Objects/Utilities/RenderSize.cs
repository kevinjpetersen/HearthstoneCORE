using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Utilities
{
    public class RenderSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public RenderSize(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
    }
}
