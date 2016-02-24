using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Ugly_Number
    {
        // new Ugly_Number().WriteResult(14)

        public void WriteResult(int num)
        {
            var rest = IsUgly(num);
            Trace.WriteLine(rest);
        }

        public bool IsUgly(int num)
        {
            if (num <= 0)
            {
                return false;
            }

            if (num == 1)
            {
                return true;
            }

            while (true)
            {
                if (num % 2 != 0)
                {
                    break;
                }
                num = num / 2;
            }

            while (true)
            {
                if (num % 3 != 0)
                {
                    break;
                }
                num = num / 3;
            }

            while (true)
            {
                if (num % 5 != 0)
                {
                    break;
                }
                num = num / 5;
            }

            if (num == 1)
            {
                return true;
            }
            return false;
        }
    }
}
