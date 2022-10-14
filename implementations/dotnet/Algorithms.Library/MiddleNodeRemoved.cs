using System;
namespace Algorithms.Library
{

    class MiddleNodeRemoved
    {
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next is null)
            {
                return null;
            }
            ListNode fast = head, slow = head, prev = null;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                prev = slow;
                slow = slow.next;
            }
            prev.next = prev.next.next;
            return head;
        }
    }
}