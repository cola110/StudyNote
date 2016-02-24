using Leetcode.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Maximum_Depth_of_Binary_Tree
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int lMax = 1 + MaxDepth(root.left);

            int rMax = 1 + MaxDepth(root.right);

            if (lMax > rMax)
            {
                return lMax;
            }
            else
            {
                return rMax;
            }
        }
    }
}
