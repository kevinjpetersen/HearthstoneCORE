using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Components
{
    public class ASCIIComponent : RenderComponent
    {
        public string AsciiFileName { get; set; }
        public ASCIIComponent(string AsciiFileName, RenderLocation Location) : base(Location)
        {
            this.AsciiFileName = AsciiFileName;
        }

        public override void Render()
        {
            RenderAsciiFile(AsciiFileName, Location);
        }
    }
}
