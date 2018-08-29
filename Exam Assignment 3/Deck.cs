using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace af222ug_examination_3
{
    public class Deck
    {
        public List<Card> deck;
        public Deck()
        {
            Initialize();
        }
        public void Initialize()
        {
            deck = new List<Card>();
            string[] suits = { "Hearts", "Clubs", "Spades", "Diamonds" };
            int[] ranks = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    deck.Add(new Card(suits[i], ranks[j]));
                }
            }
            Shuffle();
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int rndIndex = rnd.Next(deck.Count - i);
                Card swap = deck[i];
                deck[i] = deck[rndIndex];
                deck[rndIndex] = swap;
            }
        }
        public void ShowCards()
        {
            foreach(Card c in deck)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public Card DealCard()
        {
            Card toReturn = deck[0];
            deck.RemoveAt(0);
            return toReturn;
        }
    }
}