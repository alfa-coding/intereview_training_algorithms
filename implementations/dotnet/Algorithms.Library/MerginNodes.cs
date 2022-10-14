/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
namespace Algorithms.Library
{ 
    public class MerginNodes 
    {
        public ListNode MergeNodes(ListNode head)
        {
            ListNode root = null;
            ListNode front = null;
            
            while(head!=null && head.val==0)
                head= head.next;
            root= new ListNode(0);
            front = root;
            while(head!=null)
            {
                if(head.val !=0)
                {                    
                    front.val+=head.val;   
                }
                else
                {
                    if(head.next==null) break;
                    ListNode next= new ();
                    front.next=next;
                    front = front.next;
                }
                head = head.next;
                
            }   
            return root;            
        }
    }
}