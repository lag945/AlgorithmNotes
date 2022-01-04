using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1472_design_browser_history
{
    class Program
    {
        static void Main(string[] args)
        {

            BrowserHistory3 bh = new BrowserHistory3("leetcode.com");
            bh.Visit("google.com");
            bh.Visit("facebook.com");
            bh.Visit("youtube.com");
            bh.Back(1);
            bh.Back(1);
            bh.Forward(1);
            bh.Visit("linkedin.com");
            bool r1 = bh.Forward(2) == "linkedin.com";
            bool r2 = bh.Back(2) == "google.com";
            bool r3 = bh.Back(7) == "leetcode.com";



            /*
            BrowserHistory bh = new BrowserHistory("esgriv.com");
            bh.Visit("cgrt.com");
            bh.Visit("tip.com");
            bh.Back(9);
            bh.Visit("kttzxgh.com");
            bh.Forward(7);
            bh.Visit("crqje.com");
            bh.Visit("iybch.com");
            bh.Forward(5);
            bh.Visit("uun.com");
            bh.Back(10);
            bh.Visit("hci.com");
            bh.Visit("whula.com");
            bool r1 = bh.Forward(10) == "whula.com";
            */
        }

        public class BrowserHistory
        {
            //S:O(1)
            string[] m_WebSites = new string[5000];
            int m_Current = 0;
            int m_Max = 0;
            public BrowserHistory(string homepage)
            {
                m_WebSites[m_Current] = homepage;
            }

            //T:O(1)
            public void Visit(string url)
            {
                m_Max = ++m_Current;
                m_WebSites[m_Current] = url;
            }

            //T:O(1)
            public string Back(int steps)
            {
                m_Current -= steps;

                if (m_Current < 0)
                    m_Current = 0;

                return m_WebSites[m_Current];
            }

            //T:O(1)
            public string Forward(int steps)
            {
                m_Current += steps;

                if (m_Current > m_Max)
                    m_Current = m_Max;

                return m_WebSites[m_Current];
            }
        }

        public class BrowserHistory2
        {

            List<string> m_WebSites = new List<string>();
            int m_Current = 0;
            int m_Max = 0;
            public BrowserHistory2(string homepage)
            {
                m_WebSites.Add(homepage);
            }

            //T:O(1) if no adding, or T:O(n)
            public void Visit(string url)
            {
                m_Max = ++m_Current;
                if (m_Current < m_WebSites.Count)
                {
                    m_WebSites[m_Current] = url;
                }
                else//>= , but only exists == condition.
                {
                    m_WebSites.Add(url);
                }
            }

            //T:O(1)
            public string Back(int steps)
            {
                m_Current -= steps;

                if (m_Current < 0)
                    m_Current = 0;

                return m_WebSites[m_Current];
            }

            //T:O(1)
            public string Forward(int steps)
            {
                m_Current += steps;

                if (m_Current > m_Max)
                    m_Current = m_Max;

                return m_WebSites[m_Current];
            }
        }

        public class BrowserHistory3
        {

            List<string> m_WebSites = new List<string>();
            int m_Current = 0;
            public BrowserHistory3(string homepage)
            {
                m_WebSites.Add(homepage);
            }

            //T:O(n)
            public void Visit(string url)
            {

                if (m_Current == m_WebSites.Count - 1)//latest
                {
                    m_WebSites.Add(url);
                }
                else
                {
                    //https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.list-1.removerange?view=net-6.0
                    //O(n)
                    m_WebSites.RemoveRange(m_Current + 1, m_WebSites.Count - m_Current - 1);
                    m_WebSites.Add(url);
                }


                m_Current = m_WebSites.Count - 1;
            }


            public string Back(int steps)
            {
                m_Current -= steps;

                if (m_Current < 0)
                    m_Current = 0;

                return m_WebSites[m_Current];
            }

            public string Forward(int steps)
            {
                m_Current += steps;

                if (m_Current >= m_WebSites.Count)
                    m_Current = m_WebSites.Count - 1;

                return m_WebSites[m_Current];
            }
        }

        public class BrowserHistory4
        {
            Stack<string> m_Previous = new Stack<string>();
            Stack<string> m_Next = new Stack<string>();
            public BrowserHistory4(string homepage)
            {
                m_Previous.Push(homepage);
            }

            //T:O(1) = best
            public void Visit(string url)
            {
                m_Previous.Push(url);//T:O(1) or O(count)
                //m_Next.Clear();//T:O(count)
                m_Next = new Stack<string>();//T:This constructor is an O(1) operation.
            }

            //T:O(steps)
            public string Back(int steps)
            {
                while (m_Previous.Count > 1 && steps > 0)
                {
                    m_Next.Push(m_Previous.Pop());
                    steps--;
                }
                return m_Previous.Peek();
            }

            //T:O(steps)
            public string Forward(int steps)
            {
                while (m_Next.Count > 0 && steps > 0)
                {
                    m_Previous.Push(m_Next.Pop());
                    steps--;
                }
                return m_Previous.Peek();
            }
        }

        /**
         * Your BrowserHistory object will be instantiated and called as such:
         * BrowserHistory obj = new BrowserHistory(homepage);
         * obj.Visit(url);
         * string param_2 = obj.Back(steps);
         * string param_3 = obj.Forward(steps);
         */
    }
}
