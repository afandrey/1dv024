using System;

namespace af222ug_examination_2
{
    class RandomNumbers
    {
        Random rnd = new Random();
        public int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min, max + 1);
        }
        public int GetRandomShape(bool is3D)
        {
            if (!is3D)
            {
                return GetRandomNumber(0, 1);
            }
            else
            {
                return GetRandomNumber(2, 4);
            }
        }
    }
}