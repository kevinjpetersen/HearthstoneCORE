using HearthstoneCORE.Extensions;
using HearthstoneCORE.Objects.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HearthstoneCORE.Objects.Game
{
    public class HSPlayer
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        
        public Stack<HSCard> CardsInDeck { get; set; }
        public List<HSCard> CardsInHand { get; set; }
        public List<HSCard> CardsPlayed { get; set; }

        public HSCard HighlightedCard { get; set; }
        public HSCard LastPlayedCard { get; set; }

        private int CurrentCardInHandIndex = 0;

        public HSPlayer(HSDeck ChosenDeck)
        {
            CardsInHand = new List<HSCard>();
            CardsPlayed = new List<HSCard>();
            CardsInDeck = new Stack<HSCard>();

            ChosenDeck.Cards.Shuffle();

            foreach (var card in ChosenDeck.Cards)
            {
                CardsInDeck.Push(card);
            }

            DealStartCards();
        }

        public void DealStartCards()
        {
            for(int i = 0; i < 4; i++)
            {
                var card = CardsInDeck.Pop();
                card.RenderComponent = new Components.CardComponent(card, new RenderLocation(Console.WindowWidth / 2 - (i * 5), Console.WindowHeight - 28));
                CardsInHand.Add(card);
            }
        }

        public void PlayCard(HSCard card)
        {

        }

        public void GoThroughHand()
        {
            if (HighlightedCard != null) UnhighlightCard(HighlightedCard);
            if (CurrentCardInHandIndex >= CardsInHand.Count) CurrentCardInHandIndex = 0;
            HighlightCard(CardsInHand[CurrentCardInHandIndex]);
            CurrentCardInHandIndex++;
        }

        public void HighlightCard(HSCard card)
        {
            card.RenderComponent.PreviousLocation = card.RenderComponent.Location;
            card.RenderComponent.Location = new Utilities.RenderLocation(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 20);
            HighlightedCard = card;
        }

        public void UnhighlightCard(HSCard card)
        {
            card.RenderComponent.Location = card.RenderComponent.PreviousLocation;
        }
    }
}
