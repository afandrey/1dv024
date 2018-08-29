using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace af222ug_examination_1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            //int[] numbers = { 4, 8, 2, 4, 5 };
            //int[] numbers = { 4, 2, 6, 1, 3, 7, 5, 3, 7 };
            //int[] numbers = { 5, 1, 1, 1, 3, -2, 2, 5, 7, 4, 5, 16 };
            var json = File.ReadAllText("data.json");
            var numbers = JsonConvert.DeserializeObject<int[]>(json);

            dynamic stat = Statistics.DescriptiveStatistics(numbers);
            Console.WriteLine(stat);
        }
    }
}
