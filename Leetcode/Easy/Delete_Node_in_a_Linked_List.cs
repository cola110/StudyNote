using Leetcode.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    /// <summary>
    /// 删除单链表节点
    /// </summary>
    public class Delete_Node_in_a_Linked_List
    {
        public void DeleteNode(ListNode node)
        {
            if (node == null)
            {
                return;
            }

            if (node.next == null)
            {
                node = null;
            }

            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
