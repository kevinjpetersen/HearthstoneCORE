using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Game
{
    public class HSCard
    {
        public string Name { get; }
        public string Description { get; }
        public string ImageArtFileName { get; }
        public Rarities Rarity { get; }
        public int ManaCost { get; }
        public int Health { get; }
        public int Attack { get; }
        public CardTypes Type { get; }
        public List<HSModifier> Modifiers { get; }
        public List<HSAbility> Abilities { get; }

        public enum CardTypes
        {
            Spell, Humanoid, Critter, Elemental, Beast
        }

        public enum Rarities
        {
            Legendary, Epic, Rare, Common
        }

        public ConsoleColor GetRarityColor()
        {
            switch(Rarity)
            {
                case Rarities.Common:
                    return ConsoleColor.Gray;
                case Rarities.Rare:
                    return ConsoleColor.Blue;
                case Rarities.Epic:
                    return ConsoleColor.Magenta;
                case Rarities.Legendary:
                    return ConsoleColor.DarkYellow;
                default:
                    return ConsoleColor.Gray;
            }
        }

        public HSCard(string Name, string Description, string ImageArtFileName, Rarities Rarity, int ManaCost, int Health, int Attack, CardTypes Type)
        {
            this.Name = Name;
            this.Description = Description;
            this.ImageArtFileName = ImageArtFileName;
            this.Rarity = Rarity;
            this.ManaCost = ManaCost;
            this.Health = Health;
            this.Attack = Attack;
            this.Type = Type;
        }

        public void AddModifier(HSModifier modifier)
        {
            Modifiers.Add(modifier);
        }

        public void AddAbility(HSAbility ability)
        {
            Abilities.Add(ability);
        }

    }
}
