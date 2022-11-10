using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{
    public class RemoveDup
    {
        public string RemoveDuplicates(string s)
        {
            Stack<char> elements = new();
            int p1 = 0;
            while (p1 != s.Length)
            {
                if (elements.Count == 0 || s[p1] != elements.Peek())//current in s, is diff from the last on stack
                {
                    elements.Push(s[p1++]);
                    continue;
                }
                if (elements.Count != 0 && s[p1] == elements.Peek()) //I already know the stack is not empty
                {

                    elements.Pop();

                    p1++;
                }

            }
            return new String(elements.Reverse().ToArray());
        }
    }
}