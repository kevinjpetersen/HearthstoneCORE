using HearthstoneCORE.Handlers;
using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Components
{
    public class RenderComponent : ASCIIHandler
    {
        public RenderLocation Location { get; set; }
        public RenderLocation PreviousLocation { get; set; }
        public bool Enabled { get; set; }

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
