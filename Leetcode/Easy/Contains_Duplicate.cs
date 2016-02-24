using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Contains_Duplicate
    {

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            List<int> tempList = new List<int>();

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (tempList.Contains(nums[i]))
                {
                    return true;
                }
                tempList.Add(nums[i]);
            }

            return false;
        }
    }
}
