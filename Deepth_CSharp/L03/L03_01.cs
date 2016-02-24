using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Deepth_CSharp.L03
{
    public class L03_01
    {
        public static Dictionary<string, int> CountWord(string text)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            string[] words = Regex.Split(text, @"\W+");

            foreach (string word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result[word] = 1;
                }
            }
            return result;
        }


    }
}
