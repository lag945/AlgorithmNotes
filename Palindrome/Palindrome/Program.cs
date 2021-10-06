using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://web.ntnu.edu.tw/~algo/Palindrome.html
            //https://www.hackerrank.com/challenges/palindrome-index/forum
            //check("quyjjdcgsvvsgcdjjyq");
            check("hgygsvlfwcwnswtuhmyaljkqlqjjqlqkjlaymhutwsnwcflvsgygh");
            //check("fgnfnidynhxebxxxfmxixhsruldhsaobhlcggchboashdlurshxixmfxxxbexhnydinfngf");
            //check("fvyqxqxynewuebtcuqdwyetyqqisappmunmnldmkttkmdlnmnumppasiqyteywdquctbeuwenyxqxqyvf");
            //check("mmbiefhflbeckaecprwfgmqlydfroxrblulpasumubqhhbvlqpixvvxipqlvbhqbumusaplulbrxorfdylqmgfwrpceakceblfhfeibmm");
            //check("tpqknkmbgasitnwqrqasvolmevkasccsakvemlosaqrqwntisagbmknkqpt");
            //check("lhrxvssvxrhl");
            //check("prcoitfiptvcxrvoalqmfpnqyhrubxspplrftomfehbbhefmotfrlppsxburhyqnpfmqlaorxcvtpiftiocrp");
            //check("kjowoemiduaaxasnqghxbxkiccikxbxhgqnsaxaaudimeowojk");
        }

        public static void check(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                string _s = s.Remove(i, 1);
                bool ok = isPalindromeIndex(_s);
                if (ok)
                {
                    Console.WriteLine(i.ToString());
                    break;
                }
            }
            //int r = palindromeIndex(s);
            //if (r >= 0)
            //{
            //    s = s.Remove(r, 1);
            //}
            //bool ok = isPalindromeIndex(s);
            //if (ok)
            //{
            //    Console.WriteLine("pass(" + r.ToString() + "):" + s);
            //}
            //else
            //{
            //    Console.WriteLine("no pass(" + r.ToString() + "):" + s);
            //}
        }

        public static int palindromeIndex(string s)
        {
            int ret = -1;
            for (int i = 0; i < s.Length + 1 / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    if (s[i] == s[s.Length - i - 2] && s[i + 1] == s[s.Length - i - 3])
                    {
                        return s.Length - i - 1;
                    }
                    else if (s[i + 1] == s[s.Length - i - 1])
                    {
                        return i;
                    }
                }
            }

            return ret;
        }

        // 最佳解
        public static int palindromeIndex2(string s)
        {
            int l = s.Length;
            int i, j, a, b;
            for (i = 0, j = l - 1; i < l; i++, j--)
            {
                if (s[i] != s[j])
                {
                    break;
                }
            }
            if (i > j) return -1;

            for (a = i + 1, b = j; a < j && b > i + 1; a++, b--)
            {
                if (s[a] != s[b])
                {
                    return j;
                }

            }

            return i;
        }

        public static bool isPalindromeIndex(string s)
        {
            bool ret = true;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

    }
}
