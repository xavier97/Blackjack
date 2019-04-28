using System;
using System.Collections.Generic;

namespace Test
{
    public class CardGroup
    {

        private List<Card> cardList = new List<Card>();
        private int numCards;

        public int NumCards
        {
            get
            {
                return numCards;
            }
            set
            {
                numCards = value;
            }
        }

        public CardGroup()
        {
            cardList.Capacity = 52;
            numCards = 0;
        }

        // add 52 cards to an existing empty deck
        public void MakeWholeDeck()
        {
            // Add clubs
            for (int x = 2; x <= 14; x++)
            {
                // Determine face
                String face = GetFace(x);

                // construct a new CLUB card
                Card club = new Card(face, "C");

                // add it to the deck
                cardList.Add(club);
            }

            // Add spades
            for (int x = 2; x <= 14; x++)
            {
                // Determine face
                String face = GetFace(x);

                // construct a new SPADE card
                Card spade = new Card(face, "S");

                // add it to the deck
                cardList.Add(spade);
            }

            // Add hearts
            for (int x = 2; x <= 14; x++)
            {
                // Determine face
                String face = GetFace(x);

                // construct a new HEART card
                Card heart = new Card(face, "H");

                // add it to the deck
                cardList.Add(heart);
            }

            // Add diamonds
            for (int x = 2; x <= 14; x++)
            {
                // Determine face
                String face = GetFace(x);

                // construct a new DIAMOND card
                Card diamond = new Card(face, "D");

                // add it to the deck
                cardList.Add(diamond);
            }
            numCards = cardList.Count;
        }

        private string GetFace(int x)
        {
            if (x == 11)
            {
                return "J";
            }
            else if (x == 12)
            {
                return "Q";
            }
            else if (x == 13)
            {
                return "K";
            }
            else if (x == 14)
            {
                return "A";
            }
            return x.ToString();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < cardList.Count; i++)
            {
                int rndLoc = rnd.Next(0, i);
                Card card = cardList[rndLoc];
                cardList[rndLoc] = cardList[i];
                cardList[i] = card;
            }
        }

        // Remove (and return) the first card
        public Card DealTopCard()
        {
            Card topCard = cardList[0];
            cardList.RemoveAt(0);
            numCards = cardList.Count;
            return topCard;
        }

        // Returns the card at position i in the deck
        public Card GetCard(int i)
        {
            return cardList[i];
        }

        // Sets the cards at postion i to be card c
        public void SetCard(int i, Card c)
        {
            cardList[i] = c;
        }

        // Adds card c to the CardGroup (gets added at the end)
        public void AddToDeck(Card c)
        {
            cardList.Add(c);
            numCards++;
        }

        // Return list of all cards in the object
        public override string ToString()
        {
            String deckString = "";
            foreach (Card card in cardList)
            {
                deckString += card.ToString();
            }
            return deckString;
        }
    }
}