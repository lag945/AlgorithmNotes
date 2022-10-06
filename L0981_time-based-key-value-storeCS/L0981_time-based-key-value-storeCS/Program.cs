using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0981_time_based_key_value_storeCS
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeMap tm = new TimeMap();
            tm.Set("love", "high", 10);
            tm.Set("love", "low", 20);
            var r1 = tm.Get("love", 5);
            var r2 = tm.Get("love", 10);
            var r3 = tm.Get("love", 15);
            var r4 = tm.Get("love", 20);
            var r5 = tm.Get("love", 25);
            /*
            tm.Set("foo", "bar", 2);
            var r1 = tm.Get("foo", 1);
            var r2 = tm.Get("foo", 3);
            tm.Set("foo","bar2", 4);
            var r3 = tm.Get("foo", 4);
            var r4 = tm.Get("foo", 5);
            var r5 = tm.Get("foo", 0);
            */
        }

        public class TimeMap
        {

            private class TimeValue
                : IComparer<TimeValue>
            {
                public int timestamp;
                public string value;
                public TimeValue(int a_timestamp, string a_value)
                {
                    timestamp = a_timestamp;
                    value = a_value;
                }

                public int Compare(TimeValue x, TimeValue y)
                {
                    return x.timestamp - y.timestamp;
                }
            }
            Dictionary<string, List<TimeValue>> m_Dic;
            public TimeMap()
            {
                m_Dic = new Dictionary<string, List<TimeValue>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                var tv = new TimeValue(timestamp, value);
                if (!m_Dic.ContainsKey(key))
                {
                    m_Dic[key] = new List<TimeValue>();
                    m_Dic[key].Add(new TimeValue(0, ""));
                }
                m_Dic[key].Add(tv);
            }

            public string Get(string key, int timestamp)
            {
                string ret = "";
                if (!m_Dic.ContainsKey(key))
                    return ret;

                var list = m_Dic[key];

                /*
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].timestamp <= timestamp)
                        ret = list[i].value;
                }
                */

                var tv = new TimeValue(timestamp, "");
                var idx =  list.BinarySearch(tv, tv);
                if (idx < 0)
                {
                    idx = ~idx;
                    if (idx  >= list.Count)
                    {
                        //no bigger and equal
                        idx = list.Count - 1;
                        ret = list[idx].value;
                    }
                    else
                    {
                        idx -= 1;
                        if (list[idx].timestamp > timestamp)
                            ret = "";
                        else 
                            ret = list[idx].value;
                    }
                }
                else
                    ret = list[idx].value;


                return ret;


                //return ret.ToString();
            }
        }
    }
}
