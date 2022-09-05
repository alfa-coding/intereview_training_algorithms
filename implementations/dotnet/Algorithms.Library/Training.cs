using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{
    public class Training
    {

        //trapping rain water all across O(n*long(n))
        public static int CalculateRain(int[] numbers)
        {
            return CalculateRainHelper(start: 0, end: numbers.Length-1, numbers);
        }

        private static int CalculateRainHelper(int start, int end, int[] numbers)
        {
            if (start>end)
            {
                return 0;
            }

            if (end -start ==1)
            {
                return 0;
            }

            int heigh = Math.Min(numbers[start], numbers[end]);

            int largestCtrlWallPos = LargestNumberPosition(numbers, start, end, lowerTower:heigh);
            if (largestCtrlWallPos != -1)
            {
                int leftArea = CalculateRainHelper(start,largestCtrlWallPos,numbers);
                int rightArea = CalculateRainHelper(largestCtrlWallPos,end,numbers);
                return leftArea +rightArea ;
            }
            else
            {
                int width = Math.Abs(start - end) - 1;

                int sumCenter = SumAllCenter(start, end, numbers);

                return heigh * width - sumCenter;
            }
        }

        private static int SumAllCenter(int start, int end, int[] numbers)
        {
            int response = 0;
            for (int i = start + 1; i < end; i++)
            {
                response += numbers[i];
            }
            return response;
        }

        public static int LargestNumberPosition(int[] numbers, int start, int end, int lowerTower)
        {
            int response = -1;
            int largestTMP = -1;
            for (int i = start + 1; i < end; i++)
            {
                if (numbers[i] > lowerTower && numbers[i]> largestTMP)
                {
                    largestTMP = numbers[i];
                    response = i;
                }
            }

            return response;
        }

        //largest well of water
        public static int LargestWell(int[] walls)
        {
            int aPtr = 0;
            int bPtr = walls.Length - 1;
            int maxDepth = 0;

            while (aPtr < bPtr)
            {
                int heigh = Math.Min(walls[aPtr], walls[bPtr]);

                int width = bPtr - aPtr;

                int currentArea = heigh * width;

                maxDepth = Math.Max(currentArea, maxDepth);

                if (walls[aPtr] <= walls[bPtr])
                    aPtr++;
                else
                    bPtr--;



            }
            return maxDepth;
        }

        //target sum O(n)
        public static Tuple<int, int> TargetSum(int[] numbers, int target)
        {
            int[] diferences = new int[numbers.Length];
            Dictionary<int, int> valuesAndPos = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                valuesAndPos.TryAdd(numbers[i], i);
                diferences[i] = target - numbers[i];
            }

            for (int i = 0; i < diferences.Length; i++)
            {
                if (valuesAndPos.ContainsKey(diferences[i]) && i != valuesAndPos[diferences[i]])
                {
                    return new Tuple<int, int>(i, valuesAndPos[diferences[i]]);
                }
            }

            return null;
        }

        //container with more water

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
                    string concatenationCandidate = NotRepeatedCharacters(formed + words[i]) ? formed + words[i] : formed;
                    if (!marks[i])
                    {
                        marks[i] = true;
                        currentLenght = LongestConctatStringHelper(words, marks, concatenationCandidate, itemsSkippedOrTaken + 1);
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
