using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Library
{
    public class GenerateParenthesisC
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> response = new();
            Fill(response, 2 * n, 0, new List<char>());
            return response;
        }
        private void Fill(List<string> l, int n, int dif, List<char> formed)
        {
            if (dif < 0 || dif > n) return;
            if (n == 0 && dif == 0)
            {
                l.Add(new String("".Concat(formed).ToArray()));
            }
            else
            {
                formed.Add('(');
                Fill(l, n - 1, dif + 1, formed);
                formed.RemoveAt(formed.Count - 1);
                formed.Add(')');
                Fill(l, n - 1, dif - 1, formed);
                formed.RemoveAt(formed.Count - 1);
            }
        }
    }

}