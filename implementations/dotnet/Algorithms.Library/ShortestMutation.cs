using System.Collections.Generic;

namespace Algorithms.Library
{
    class ShortestMutation
    {


        public int MinMutation(string start, string end, string[] bank)
        {
            Queue<pair> q = new();
            // converting vector of bank to set of wordList 
            // because it is easier to search as word in set then in a vector
            HashSet<string> s = new HashSet<string>(bank);
            string genes = "ACGT";

            q.Enqueue(new pair { first = start, second = 0 }); // holds the beginning word and initial step as 0

            // we are nor erasing start word from set 'bank' as it is given that,
            // starting point is assumed to be valid, so it might not be included in the bank.

            while (q.Count != 0)
            {
                string word = q.Peek().first;
                int count = q.Peek().second;
                q.Dequeue();

                if (word == end) return count;

                // traverse through all the characters of the word
                for (int i = 0; i < word.Length; i++)
                {
                    string original = word;
                    var arr = word.ToCharArray();
                    // change each character to some different letters from 'A', 'C', 'G', and 'T'.
                    foreach (char ch in genes)
                    {
                        arr[i] = ch;
                        var formed = new string(arr);
                        // if any of the word exist in bank we will take that word
                        if (s.Contains(formed))
                        {
                            s.Remove(formed);
                            q.Enqueue(new pair { first = formed, second = count + 1 });
                        }
                    }
                    word = original; // undo the changes made.
                }
            }
            return -1;
        }


    }
    class pair
    {
        public string first;
        public int second;
    }
}