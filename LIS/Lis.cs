using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS
{
    public class Lis
    {
        public string FindLis(string input)
        {
            int[] numbers = input.Split(' ').Select(s => int.Parse(s)).ToArray();
            var lis = FindLis(numbers);
            if (lis != null)
                return String.Join(' ', Array.ConvertAll<int, String>(numbers, Convert.ToString), lis.StartIndex, (lis.EndIndex - lis.StartIndex + 1));
            else
                return null;
        }

        private Sequence FindLis(int[] numbers)
        {
            List<Sequence> sequences = new List<Sequence>();
            var count = numbers.Length;
            List<int> dest = new List<int>();

            Sequence sequence = null;
            for (int i = 0; i < count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    if (sequence == null)
                    {
                        sequence = new Sequence();
                        sequence.StartIndex = i;
                        sequence.EndIndex = i + 1;
                    }
                    else
                    {
                        sequence.EndIndex = i + 1;
                    }
                }
                else
                {
                    if (sequence != null)
                    {
                        sequences.Add(sequence);
                        sequence = null;
                    }
                }
            }

            if (sequence != null)
            {
                sequences.Add(sequence);
                sequence = null;
            }

            if (sequences.Count == 1)
                return sequences[0];
            else if (sequences.Count > 1)
            {
                var maxLength = sequences.Max(m => m.Length);
                return sequences.Where(w => w.Length == maxLength).FirstOrDefault();
            }
            else
                return null;
        }
    }
}
