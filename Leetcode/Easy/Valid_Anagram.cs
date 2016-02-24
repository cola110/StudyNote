using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Valid_Anagram
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {

            if (s.Length != t.Length)
            {
                return false;
            }

            List<char> searchAfter = new List<char>();
            foreach (char item in s)
            {
                if (searchAfter.Contains(item))
                {
                    continue;
                }
                int sCount = s.Count(e => e == item);
                int tCount = t.Count(e => e == item);

                if (sCount != tCount)
                {
                    return false;
                }

                searchAfter.Add(item);
            }

            return true;

            //if (s.Length != t.Length)
            //{
            //    return false;
            //}
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //foreach (char item in s)
            //{
            //    int i = t.IndexOf(item);
            //    if (i < 0)
            //    {
            //        return false;
            //    }
            //    t = t.Remove(i, 1);
            //}

            //watch.Stop();
            //long spend = watch.ElapsedMilliseconds;
            //return true;
        }
    }
}
