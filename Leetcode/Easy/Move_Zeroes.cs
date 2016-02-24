using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Move_Zeroes
    {
        /// <summary>
        /// 0后置
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            #region 方法01
            //int[] tempNums = new int[nums.Length];

            //int backPosition = nums.Length - 1;
            //int position = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == 0)
            //    {
            //        tempNums[backPosition] = nums[i];
            //        backPosition--;
            //    }
            //    else
            //    {
            //        tempNums[position] = nums[i];
            //        position++;
            //    }
            //}
            #endregion

            int backposition = nums.Length - 1;

            List<int> list = nums.ToList();

            var zeroList = list.FindAll(e => e == 0);
            var nonOList = list.FindAll(e => e != 0);

            // nums = new int[]{zeroList.ToList(),}
            var restList = nonOList.ToList();
            restList.AddRange(zeroList);

            var tempNums = restList.ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = tempNums[i];
            }

            nums = tempNums;
        }
    }
}
