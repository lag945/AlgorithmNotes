using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1286_IteratorforCombinationCS
{
    class Program
    {
        static void Main(string[] args)
        {

            CombinationIterator c = new CombinationIterator("abc", 2);
            bool r = c.HasNext();
            string ret = c.Next();
            ret = c.Next();
            ret = c.Next();
            r = c.HasNext();
        }

        public class CombinationIterator
        {
            Queue<string> answer = new Queue<string>();
            StringBuilder sb = null;
            public CombinationIterator(string characters, int combinationLength)
            {
                sb = new StringBuilder(combinationLength);
                if (combinationLength <= characters.Length)
                {
                    char[] chars = characters.ToCharArray();
                    for (int i = 0; i < chars.Length; i++)
                    {
                        Append(new char[] { characters[i] }, chars, i, combinationLength);
                    }
                }
            }

            public void Append(char[] letters, char[] characters, int index, int combinationLength)
            {
                if (index >= characters.Length) return;
                if (letters.Length == combinationLength)
                {
                    sb.Clear();
                    for (int i = 0; i < letters.Length; i++)
                    {
                        sb.Append(letters[i]);
                    }
                    answer.Enqueue(sb.ToString());
                    return;
                }
                index++;
                for (int i = index; i < characters.Length; i++)
                {
                    List<char> _letters = new List<char>();
                    _letters.AddRange(letters);
                    _letters.Add(characters[i]);
                    Append(_letters.ToArray(), characters, i, combinationLength);
                }
            }


            public string Next()
            {
                return answer.Dequeue();
            }

            public bool HasNext()
            {
                return answer.Count > 0;
            }
        }

        /**
         * Your CombinationIterator object will be instantiated and called as such:
         * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
         * string param_1 = obj.Next();
         * bool param_2 = obj.HasNext();
         */
    }
}
