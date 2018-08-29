using System;
using System.Collections.Generic;

namespace af222ug_examination_3
{
    public class Hand
    {
        public List<Card> hand = new List<Card>();

        public void Hit(Deck deck)
        {
            hand.Add(deck.DealCard());
        }
        public List<Card> ShowHand()
        {
            return hand;
        }
        public void DisplayHand()
        {
            foreach(Card c in hand)
            {
                Console.Write(c.ToString() + ", ");
            }
        }
        public int Total()
        {
            int sum = 0;
            int aces = 0;
            foreach(Card c in hand)
            {
                if (c.Value == 14)
                {
                    aces += 1;
                }
                sum += c.Value;
            }
            while (sum > 21 && aces > 0)
            {
                sum -= 13;
                aces -= 1;
            }
            return sum;
        }

        public void ThrowCards() 
        {
            hand.Clear();
        }
    }
}