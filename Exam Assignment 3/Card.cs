using System;

namespace af222ug_examination_3
{
    public class Card
    {
        private int numVal;
        private string suit;
        public int Value {get {return numVal; }}
        public string value
        {
            get
            {
                if (numVal == 14)
                {
                    return "A";
                }
                else if (numVal == 13)
                {
                    return "K";
                }
                else if (numVal == 12)
                {
                    return "Q";
                }
                else if (numVal == 11)
                {
                    return "J";
                }
                else
                {
                    return numVal.ToString();
                }
            }
        }
        public Card(string s, int v)
        {
            suit = s;
            numVal = v;
        }
        public override string ToString()
        {
            return value + " of " + suit;
        }
    }
}