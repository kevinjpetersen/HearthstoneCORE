using HearthstoneCORE.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects
{
    public class RenderComponent : ASCIIHandler
    {
        public RenderLocation Location { get; set; }

        public RenderComponent(RenderLocation Location)
        {
            this.Location = Location;
        }

        public virtual void Render() { }

        public void Translate(RenderLocation direction)
        {
            if (Location.X >= Console.BufferWidth) Location.X = 0;
            if (Location.Y >= Console.BufferWidth) Location.Y = 0;

            Location.X += direction.X;
            Location.Y += direction.Y;
        }
    }
}
