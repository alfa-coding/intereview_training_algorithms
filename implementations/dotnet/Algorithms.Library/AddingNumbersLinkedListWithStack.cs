using System;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class AddingNumbersLinkedListWithStack
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1s = new Stack<int>();
            var l2s = new Stack<int>();
            var repS = new Stack<int>();

            while (l1 != null)
            {
                l1s.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                l2s.Push(l2.val);
                l2 = l2.next;
            }

            int resto = 0;
            int currentSum = 0;

            while (l1s.Count != 0 && l2s.Count != 0)
            {
                currentSum = l1s.Pop() + l2s.Pop() + resto;
                if (currentSum >= 10)
                {
                    resto = 1;
                    repS.Push(currentSum - 10);
                }
                else
                {
                    repS.Push(currentSum);
                    resto = 0;
                }

            }

            if (l1s.Count == 0)
            {
                //play with ls2
                while (l2s.Count != 0)
                {
                    currentSum = l2s.Pop() + resto;
                    if (currentSum >= 10)
                    {
                        resto = 1;
                        repS.Push(currentSum - 10);
                    }
                    else
                    {
                        repS.Push(currentSum);
                        resto = 0;
                    }

                }

            }
            if (l2s.Count == 0)
            {
                //play with ls1
                while (l1s.Count != 0)
                {
                    currentSum = l1s.Pop() + resto;
                    if (currentSum >= 10)
                    {
                        resto = 1;
                        repS.Push(currentSum - 10);
                    }
                    else
                    {
                        repS.Push(currentSum);
                        resto = 0;
                    }
                }

            }
            if (repS.Count == 0) return null;

            ListNode response = new ListNode(resto>1?1:repS.Pop());
            ListNode cursor = response;

            while (repS.Count != 0)
            {
                cursor.next = new ListNode(repS.Pop());
                cursor = cursor.next;
            }
           
            return response;

        }
    }

}