using Leetcode.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    /// <summary>
    /// 反转二叉树
    /// </summary>
    public class Invert_Binary_Tree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            TreeNode tempNode = root.left;
            root.left = root.right;
            root.right = tempNode;

            root.left = InvertTree(root.left);
            root.right = InvertTree(root.right);
            return root;
        }
    }
}
