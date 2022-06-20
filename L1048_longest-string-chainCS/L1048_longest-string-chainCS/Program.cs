using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1048_longest_string_chainCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string[] words = new string[] { "wnyxmflkf", "xefx", "usqhb", "ttmdvv", "hagmmn", "tmvv", "pttmdvv", "nmzlhlpr", "ymfk", "uhpaglmmnn", "zckgh", "hgmmn", "isqxrk", "isqrk", "nmzlhpr", "uysyqhxb", "haglmmn", "xfx", "mm", "wymfkf", "tmdvv", "uhaglmmn", "mf", "uhaglmmnn", "mfk", "wnymfkf", "powttkmdvv", "kwnyxmflkf", "xx", "rnqbhxsj", "uysqhb", "pttkmdvv", "hmmn", "iq", "m", "ymfkf", "zckgdh", "zckh", "hmm", "xuefx", "mv", "iqrk", "tmv", "iqk", "wnyxmfkf", "uysyqhb", "v", "m", "pwttkmdvv", "rnqbhsj" };
            bool r = s.LongestStrChain2(words) == 10;
        }

        public class Solution
        {


            public int LongestStrChain2(string[] words)
            {
                int max = 1;
                Array.Sort(words, (a, b) => { return a.Length - b.Length; });

                Dictionary<string, int> map = new Dictionary<string, int>();
                foreach (string w in words)
                {
                    int longest = 1;
                    for (int i = 0; i < w.Length; i++)
                    {
                        string _w = w.Remove(i, 1);
                        if (map.ContainsKey(_w))
                        {
                            longest = Math.Max(longest, map[_w] + 1);
                        }
                    }
                    map[w] = longest;
                    max = Math.Max(max,longest);
                }

                return max;
            }
            public int LongestStrChain(string[] words)
            {
                int ret = 1;
                Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();

                foreach (string w in words)
                {
                    if (!map.ContainsKey(w.Length))
                    {
                        map[w.Length] = new List<string>();
                    }
                    map[w.Length].Add(w);
                }

                for (int i = 16; i >= 1; i--)
                {
                    if (!map.ContainsKey(i))
                        continue;

                    for (int j = 0; j < map[i].Count; j++)
                    {
                        Find(map[i][j], i, 0, ref ret, map);
                    }
                }

                return ret;
            }

            private void Find(string w, int len, int cnt, ref int max, Dictionary<int, List<string>> map)
            {
                //Console.WriteLine(w);
                int count = 0;
                for (int i = 0; i < map[len].Count; i++)
                {
                    if (map[len][i] == w)
                    {
                        count++;
                        break;
                    }
                }

                if (count == 0)
                    return;

                cnt += count;
                max = Math.Max(cnt, max);

                len--;
                if (!map.ContainsKey(len))
                    return;

                if (w.Length == 1)
                    return;

                for (int i = 0; i < w.Length; i++)
                {
                    Find(w.Remove(i, 1), len, cnt, ref max, map);
                }
            }

        }
    }
}
