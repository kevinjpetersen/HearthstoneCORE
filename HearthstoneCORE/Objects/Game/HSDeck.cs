using System;
using System.Collections.Generic;
using System.Text;

namespace HearthstoneCORE.Objects.Game
{
    public class HSDeck
    {
        private List<HSCard> cards;

        public List<HSCard> Cards
        {
            get
            {
                return Cards;
            }
        }

        public HSDeck()
        {
            cards = new List<HSCard>();
        }

        public void AddCard(HSCard card)
        {
            cards.Add(card);
        }

        public void RemoveCard(HSCard card)
        {
            cards.Remove(card);
        }


    }
}
