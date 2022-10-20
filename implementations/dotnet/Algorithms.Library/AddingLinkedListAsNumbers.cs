using System;

namespace Algorithms.Library
{
    public class AddingLinkedListAsNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int resto = 0;
            bool wasL1 = l1 == null;
            bool wasL2 = l2 == null;

            ListNode response = new ListNode();
            ListNode currentResponse = response;

            var currentL1 = l1;
            var currentL2 = l2;
            int currentSum = 0;
            while (!wasL1 && !wasL2)
            {
                currentSum = currentL1.val + currentL2.val + resto;
                if (currentSum >= 10)
                {
                    currentResponse.val = currentSum - 10;
                    resto = 1;
                }
                else
                {
                    currentResponse.val = currentSum;
                    resto = 0;
                }

                currentL1 = currentL1.next;
                currentL2 = currentL2.next;




                if (currentL1 == null)
                    wasL1 = true;

                if (currentL2 == null)
                    wasL2 = true;

                if (currentL1 != null && currentL2 != null)
                {
                    //solo quiero que haya next, si habra otra suma
                    //con seguridad
                    currentResponse.next = new ListNode();
                    currentResponse = currentResponse.next;

                }


            }

            if (wasL1)
            {

                //seguir con el segundo
                while (currentL2 != null)
                {
                    currentSum = currentL2.val + resto;

                    if (currentSum >= 10)
                    {
                        currentResponse.next = new ListNode(currentSum - 10);
                        resto = 1;
                    }
                    else
                    {
                        currentResponse.next = new ListNode(currentSum);
                        resto = 0;
                    }

                    currentL2 = currentL2.next;
                    currentResponse = currentResponse.next;
                    
                }
            }
            if (wasL2)
            {

                //seguir con el primero
                while (currentL1 != null)
                {
                    currentSum = currentL1.val + resto;

                    if (currentSum >= 10)
                    {
                        currentResponse.next = new ListNode(currentSum - 10);
                        resto = 1;
                    }
                    else
                    {
                        currentResponse.next = new ListNode(currentSum);
                        resto = 0;
                    }

                    currentL1 = currentL1.next;
                    currentResponse = currentResponse.next;
                    
                }
            }
            if (resto > 0)
            {
                currentResponse.next = new ListNode(1);
                currentResponse = currentResponse.next;
            }

            return response;
        }
    }
}