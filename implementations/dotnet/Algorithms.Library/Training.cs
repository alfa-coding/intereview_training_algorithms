using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{
    public class Training
    {

        //O(n)
        public static Tuple<int,int> TargetSum(int[]numbers, int target)
        {
            int [] diferences = new int[numbers.Length];
            Dictionary<int,int> valuesAndPos = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                valuesAndPos.TryAdd(numbers[i],i);
                diferences[i] = target - numbers[i];
            }   
            
            for (int i = 0; i < diferences.Length; i++)
            {
                if (valuesAndPos.ContainsKey(diferences[i])&&i!=valuesAndPos[diferences[i]])
                {
                    return new Tuple<int, int>(i,valuesAndPos[diferences[i]]);
                }
            }

            return null;
        }

        public static int LongestConctatString(string[] words)
        {
            return LongestConctatStringHelper(words, new bool[words.Length], "", 0);
        }

        private static int LongestConctatStringHelper(string[] words, bool[] marks, string formed, int itemsSkippedOrTaken)
        {
            if (itemsSkippedOrTaken == words.Length)
            {
                if (words.Contains(formed))
                {
                    return 0;
                }
                return formed.Length;
            }

            else
            {
                int maxLengh = 0;
                int currentLenght = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    string concatenationCandidate = formed + words[i];
                    if (!marks[i])
                    {
                        marks[i] = true;

                        if (NotRepeatedCharacters(concatenationCandidate))
                        {
                            currentLenght = LongestConctatStringHelper(words, marks, concatenationCandidate, itemsSkippedOrTaken + 1);

                        }
                        else
                        {
                            currentLenght = LongestConctatStringHelper(words, marks, formed, itemsSkippedOrTaken + 1);
                        }
                        maxLengh = Math.Max(maxLengh, currentLenght);
                        marks[i] = false;
                    }
                }

                return maxLengh;
            }

        }

        private static bool NotRepeatedCharacters(string concatenationCandidate)
        {
            return concatenationCandidate.Distinct().Count() == concatenationCandidate.Length;
        }
    }
}
