using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace af222ug_examination_1
{
    static class Statistics
    {
        public static dynamic DescriptiveStatistics(int[] source)
        {
            int max = Maximum(source);
            int min = Minimum(source);
            double mean = Mean(source);
            double median = Median(source);
            int[] mode = Mode(source);
            int range = Range(source);
            double standardDeviation = StandardDeviation(source);

            var stringmode = string.Join(",", mode);

            return $"Maxmimum: {max}\n" + $"Minimum: {min}\n" + $"Medelvärde: {mean}\n" + $"Median: {median}\n"
            + $"Typvärde: {stringmode}\n" + $"Variationsbredd: {range}\n" + $"Standardavvikelse: {standardDeviation}";
        }
        public static int Maximum(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                return source.Max();
            }
        }
        public static double Mean(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                double sum = 0;

                foreach (int x in source)
                {
                    sum += x;
                }
                return sum / source.Length;
            }
        }
        public static double Median(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                int[] sortedNumbers = (int[])source.Clone();
                Array.Sort(sortedNumbers);
                int size = sortedNumbers.Length;
                int mid = size / 2;
                return (size % 2 != 0) ? (double)sortedNumbers[mid] : ((double)sortedNumbers[mid] + (double)sortedNumbers[mid - 1]) / 2;
            }
        }
        public static int Minimum(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                return source.Min();
            }
        }
        public static int[] Mode(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                int[] sortedNumbers = (int[])source.Clone();
                Array.Sort(sortedNumbers);

                var mode = sortedNumbers.GroupBy(i => i)
                         .Select(i => new { Count = i.Count(), num = i.Key })
                         .GroupBy(i => i.Count, i => i.num)
                         .OrderByDescending(i => i.Key)
                         .First();

                return mode.ToArray();
            }
        }
        public static int Range(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                return source.Max() - source.Min();
            }
        }
        public static double StandardDeviation(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            else if (source.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            else
            {
                double average = (double)source.Average();
                double sumOfSquareDifference = source.Select(val => (val - average) * (val - average)).Sum();

                return Math.Sqrt(sumOfSquareDifference / source.Length);
            }
        }
    }
}