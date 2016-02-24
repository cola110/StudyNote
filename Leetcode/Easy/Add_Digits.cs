using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Add_Digits
    {
        /// <summary>
        /// 求数根
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddDigits(int num)
        {
            if (num <= 9)
            {
                return num;
            }

            var result = num % 9;
            if (result == 0)
            {
                result = 9;
            }
            return result;
        }
    }
}
