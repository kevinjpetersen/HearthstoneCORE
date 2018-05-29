using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Components
{
    public class TextComponent : RenderComponent
    {
        public string Text { get; set; }

        public TextComponent(string Text, RenderLocation Location) : base(Location)
        {
            this.Text = Text;
        }

        public override void Render()
        {
            RenderText(Text, Location);
        }
    }
}
