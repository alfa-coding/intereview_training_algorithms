using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Training
    {
        public TreeNode PruneTree(TreeNode root)
        {
            return HasOnes(root)?root:null;
        }

        private bool HasOnes(TreeNode root)
        {
            if (root is null)
            {
                return false;
            }

            bool leftHasOnes = HasOnes(root.left);
            if (!leftHasOnes)
            {
                root.left = null;
            }
            bool rightHasOnes = HasOnes(root.right);
            if (!rightHasOnes)
            {
                root.right = null;
            }



            return root.val==1 || leftHasOnes || rightHasOnes;
        }

        public static IList<IList<int>> LevelOrder(Node root)
        {

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            List<IList<int>> response = new List<IList<int>>();
            while (queue.Count != 0)
            {

                int size = queue.Count;

                List<int> level = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    Node tmp = queue.Dequeue();
                    level.Add(tmp.val);
                    foreach (var child in tmp.children)
                    {
                        queue.Enqueue(child);

                    }
                }
                response.Add(level);




            }

            return response;
        }

        public static bool TypedOutStrings(string a, string b)
        {
            char[] aCleaned = new char[a.Length];
            char[] bCleaned = new char[b.Length];

            int indexA = 0;
            int indexB = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '#' && indexA > 0)
                {
                    indexA--;
                }
                if (a[i] != '#')
                {
                    aCleaned[indexA++] = a[i];
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == '#' && indexB > 0)
                {
                    indexB--;
                }
                if (b[i] != '#')
                {
                    bCleaned[indexB++] = b[i];
                }
            }
            if (indexA != indexB)
            {
                return false;
            }
            for (int i = 0; i < Math.Min(indexA, indexB); i++)
            {
                if (aCleaned[i] != bCleaned[i])
                    return false;
            }
            return true;


        }

        public static int CalculateRain(int[] numbers)
        {
            //return CalculateRainHelper(start: 0, end: numbers.Length-1, numbers);
            return CalculateRainHelperLinear(start: 0, end: numbers.Length - 1, numbers);

        }


        //O(n)
        private static int CalculateRainHelperLinear(int start, int end, int[] numbers)
        {
            int totalAmount = 0;
            int maxLeftSeen = 0;
            int maxRightSeen = 0;


            while (start < end)
            {
                if (numbers[start] <= numbers[end])
                {
                    //do calculate the water to the left, or do we
                    if (maxLeftSeen > numbers[start])
                    {
                        totalAmount += maxLeftSeen - numbers[start];
                    }
                    //update the max
                    else
                    {
                        maxLeftSeen = numbers[start];
                    }
                    start++;
                }
                else
                {
                    //we are moving backwards

                    //do we calculate the water to the right, or do we
                    if (maxRightSeen > numbers[end])
                    {
                        totalAmount += maxRightSeen - numbers[end];
                    }
                    //update the max
                    else
                    {
                        maxRightSeen = numbers[end];
                    }
                    end--;
                }


            }

            return totalAmount;
        }

        //trapping rain water all across O(n*long(n))
        private static int CalculateRainHelper(int start, int end, int[] numbers)
        {
            if (start > end)
            {
                return 0;
            }

            if (end - start == 1)
            {
                return 0;
            }

            int heigh = Math.Min(numbers[start], numbers[end]);

            int largestCtrlWallPos = LargestNumberPosition(numbers, start, end, lowerTower: heigh);
            if (largestCtrlWallPos != -1)
            {
                int leftArea = CalculateRainHelper(start, largestCtrlWallPos, numbers);
                int rightArea = CalculateRainHelper(largestCtrlWallPos, end, numbers);
                return leftArea + rightArea;
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
                if (numbers[i] > lowerTower && numbers[i] > largestTMP)
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
