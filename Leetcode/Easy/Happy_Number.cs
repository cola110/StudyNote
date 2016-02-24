using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Happy_Number
    {
        public bool IsHappy(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            if (n == 1)
            {
                return true;
            }

            List<int> tempList = new List<int>();
            tempList.Add(n);
            int single = 0;
            int sum = 0;
            while (true)
            {
                while (true)
                {
                    single = n % 10;
                    sum += (single * single);
                    n = (n - single) / 10;
                    if (n <= 0)
                    {
                        break;
                    }
                }

                if (tempList.Contains(sum))
                {
                    return false;
                }
                else
                {
                    tempList.Add(sum);
                }

                if (sum == 1)
                {
                    return true;
                }
                n = sum;
                sum = 0;
            }
        }
    }
}
