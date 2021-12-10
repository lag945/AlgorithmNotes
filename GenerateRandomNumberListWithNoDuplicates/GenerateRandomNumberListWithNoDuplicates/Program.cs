using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRandomNumberListWithNoDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ret1 = GenerateNotRepeatingNumbersRandom(6);
            List<int> ret2 = GenerateRandomWithoutRepeat(5, 1, 6);

            // no repeating.
            Func<int[], bool> validate = (list) =>
             {
                 bool ret = true;
                 HashSet<int> set = new HashSet<int>();
                 foreach (int n in list)
                 {
                     ret = set.Add(n);
                     if (!ret)
                         break;
                 }
                 return ret;
             };

            bool v1 = validate(ret1);
            bool v2 = validate(ret2.ToArray());
        }

        /// <summary>
        /// Generate not repeating numbers randomly.
        /// </summary>
        /// <param name="max">All candidates are less than max.</param>
        /// <returns></returns>
        public static int[] GenerateNotRepeatingNumbersRandom(int max)
        {
            int[] ret = new int[max];
            int zeroIndex = 0;
            Random random = new Random();

            Action<int, int> swap = (x, y) =>
            {
                int temp = ret[x];
                ret[x] = ret[y];
                ret[y] = temp;
            };

            //swap every candidates randomly.
            for (int i = 0; i < ret.Length; i++)
            {
                if (i != zeroIndex && ret[i] == 0)//Initialize
                    ret[i] = i;
                int target = random.Next(max);
                if (target != zeroIndex && ret[target] == 0)//Initialize
                    ret[target] = target;

                if (i == zeroIndex)
                    zeroIndex = target;
                else if (target == zeroIndex)
                    zeroIndex = i;

                swap(i, target);
            }

            return ret;
        }

        // https://stackoverflow.com/questions/17778723/generating-random-numbers-without-repeats

        // https://forum.unity.com/threads/random-number-without-repeat.497923/
        /// <summary>
        ///  Generate count candidates which represents values that range from min to max without repeat.
        /// </summary>
        /// <param name="count">Which represents values that range from 0 to (max-min).</param>
        /// <param name="min">All candidates are greater than and equal to min.</param>
        /// <param name="max">All candidates are less than max.</param>
        /// <returns></returns>
        public static List<int> GenerateRandomWithoutRepeat(int count, int min, int max)
        {
            if (max <= min || count < 0 ||
                    (count > max - min && max - min > 0))
            {
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                        " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }
            Random random = new Random();

            HashSet<int> candidates = new HashSet<int>();

            for (int top = max - count; top < max; top++)
            {
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    candidates.Add(top);
                }
            }

            List<int> result = candidates.ToList();

            for (int i = result.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }

    }
}
