using Leetcode.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Same_Tree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            bool rOk = IsSameTree(p.right, q.right);
            if (!rOk)
            {
                return false;
            }

            bool lOk = IsSameTree(p.left, q.left);

            return lOk;
        }
    }
}
