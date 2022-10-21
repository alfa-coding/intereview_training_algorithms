using System.Collections.Generic;
using System.Text;

public class BinarySum
{
    public string AddBinary(string a, string b) {
        var l1s = new Stack<int>();
            var l2s = new Stack<int>();
            var repS = new Stack<int>();
            
            int idxL1 = 0;
            int idxL2 = 0;
        
            while (idxL1<a.Length)
            {
                l1s.Push(a[idxL1]-48);
                idxL1++;
            }
            while (idxL2 <b.Length)
            {
                l2s.Push(b[idxL2]-48);
                idxL2++;
            }

            int resto = 0;
            int currentSum = 0;

            while (l1s.Count != 0 && l2s.Count != 0)
            {
                currentSum = l1s.Pop() + l2s.Pop() + resto;
                if (currentSum >= 2)
                {
                    resto = 1;
                    repS.Push(currentSum - 2);
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
                    if (currentSum >= 2)
                    {
                        resto = 1;
                        repS.Push(currentSum - 2);
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
                    if (currentSum >= 2)
                    {
                        resto = 1;
                        repS.Push(currentSum - 2);
                    }
                    else
                    {
                        repS.Push(currentSum);
                        resto = 0;
                    }
                }

            }
            if (repS.Count == 0) return "";

            StringBuilder response = new StringBuilder();

            response.Append(resto>0?1:repS.Pop());
            

            while (repS.Count != 0)
            {
                response.Append(repS.Pop());
                
            }
            
            return response.ToString();
    }
}