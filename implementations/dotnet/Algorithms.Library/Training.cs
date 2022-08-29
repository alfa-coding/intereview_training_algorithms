using System;
using System.Linq;

namespace Algorithms.Library
{
    public class Training
    {
        public static int LongestConctatString(string[] words)
        {
            return LongestConctatStringHelper(words, new bool[words.Length], "", 0);
        }

        private static int LongestConctatStringHelper(string[] words, bool[] marks, string formed, int itemsSkippedOrTaken)
        {
            if (itemsSkippedOrTaken == words.Length)
            {
                return formed.Length;
            }

            else
            {
                int maxLengh = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    string concatenationCandidate = formed + words[i];
                    if (!marks[i] && NotRepeatedCharacters(concatenationCandidate))
                    {
                        marks[i]=true;
                        int currentLenght =LongestConctatStringHelper(words,marks,concatenationCandidate,itemsSkippedOrTaken+1);
                        maxLengh = Math.Max(maxLengh,currentLenght);
                        marks[i]=false;
                    }
                }

                return Math.Max(maxLengh,formed.Length);
            }
            
        }

        private static bool NotRepeatedCharacters(string concatenationCandidate)
        {
            return concatenationCandidate.Distinct().Count()==concatenationCandidate.Length;
        }
    }
}
