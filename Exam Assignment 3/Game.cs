using System;

namespace af222ug_examination_3
{
    public class Game
    {

        Deck myDeck = new Deck();
        Hand[] players = new Hand[1];
        Hand dealer = new Hand();
        public void Play()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Hand();
            }
            PlayerCards();
            // display each player and players total
            // displays one dealer (with same cards) for every playerw
            for (int i = 0; i < players.Length; i++)
            {
                DealerCards();
                if (players[i].Total() > 21)
                {
                    Console.Write("Player" + i + ": ");
                    players[i].DisplayHand();
                    Console.WriteLine("(" + players[i].Total() + ") BUSTED!");
                    Console.WriteLine("Dealer: -");
                    Console.WriteLine("Dealer wins!");
                    Console.WriteLine();
                }
                else if (players[i].Total() == 21 && players[i].ShowHand().Count == 2)
                {
                    Console.Write("Player" + i + ": ");
                    players[i].DisplayHand();
                    Console.WriteLine("(" + players[i].Total() + ")");
                    Console.WriteLine("Dealer: -");
                    Console.WriteLine("Player" + i + " blackjack!");
                    Console.WriteLine();
                }
                else if (players[i].Total() > dealer.Total())
                {
                    Console.Write("Player" + i + ": ");
                    players[i].DisplayHand();
                    Console.WriteLine("(" + players[i].Total() + ")");
                    DisplayDealer();
                    Console.WriteLine("Player" + i + " wins!");
                    Console.WriteLine();
                }
                else if (dealer.Total() > 21)
                {
                    Console.Write("Player" + i + ": ");
                    players[i].DisplayHand();
                    Console.WriteLine("(" + players[i].Total() + ")");
                    DisplayDealer();
                    Console.WriteLine("Player" + i + " wins!");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Player" + i + ": ");
                    players[i].DisplayHand();
                    Console.WriteLine("(" + players[i].Total() + ")");
                    DisplayDealer();
                    Console.WriteLine("Dealer wins!");
                    Console.WriteLine();
                }
                dealer.ThrowCards();
            }
        }
        public void PlayerCards()
        {
            foreach (Hand p in players)
            {
                int count = p.ShowHand().Count;
                p.Hit(myDeck);
                p.Hit(myDeck);
                while (p.Total() < 15 && count < 5)
                {
                    p.Hit(myDeck);
                }
            }
        }
        public void DealerCards()
        {
            int count = dealer.ShowHand().Count;
            dealer.Hit(myDeck);
            dealer.Hit(myDeck);
            while (dealer.Total() < 15 && count < 5)
            {
                dealer.Hit(myDeck);
            }
        }
        public void DisplayDealer()
        {
            Console.Write("Dealer: ");
            dealer.DisplayHand();
            Console.Write("(" + dealer.Total() + ")");
            if (dealer.Total() > 21)
            {
                Console.Write(" BUSTED!");
            }
            Console.WriteLine();
        }
    }
}