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

        //weak characters
        public int NumberOfWeakCharacters(int[][] properties)
        {
            int total = 0;
            //si ataques iguales, ordena por defensa
            Array.Sort(properties, (par1, par2) => par2[0] == par1[0] ? par1[1] - par2[1] : par2[0] - par1[0]);

            //Como eran menores, que el mayor que habia encontrado, no he de recontarlos
            //actualizar el mayor
            int md = 0;
            foreach (int[] prop in properties)
            {
                if (prop[1] < md) total++;
                md = Math.Max(md, prop[1]);
            }
            return total;
        }

        public static void DFSRecursive<T>(T source, DirectedAsyclicGraph<T> graph)
        {
            System.Console.WriteLine(source);

            foreach (var neighbor in graph.AdjacencyList[source])
            {
                DFSRecursive(neighbor, graph);
            }
        }
        public static void DFSStackBased<T>(T source, DirectedAsyclicGraph<T> graph)
        {
            Stack<T> stack = new Stack<T>();
            stack.Push(source);
            while (stack.Count != 0)
            {
                T current = stack.Pop();
                System.Console.WriteLine(current);

                foreach (var neighbor in graph.AdjacencyList[current])
                {
                    stack.Push(neighbor);
                }
            }

        }

        public static void BFSQueueBased<T>(T source, DirectedAsyclicGraph<T> graph)
        {
            Queue<T> stack = new Queue<T>();
            stack.Enqueue(source);
            while (stack.Count != 0)
            {
                T current = stack.Dequeue();
                System.Console.WriteLine(current);

                foreach (var neighbor in graph.AdjacencyList[current])
                {
                    stack.Enqueue(neighbor);
                }
            }

        }
        public static int Reverse(int x)
        {

            long total = 0;
            int sign = x < 0 ? -1 : 1;
            int maxPositive = Int32.MaxValue;
            long maxNegative = (long)Int32.MaxValue + 1;
            long prefix = 0;

            if (sign > 0 && x >= maxPositive)
                return 0;
            if (sign < 0 && (long)Math.Abs((long)x) >= maxNegative)
                return 0;
            int exponent = (int)Math.Log((long)Math.Abs(x), 10);
            int lastDigit = 0;
            if (x > 0)
            {
                while (x > 0)
                {
                    lastDigit = x % 10;
                    prefix = lastDigit * (long)Math.Pow(10, exponent--);
                    if (prefix >= maxPositive || prefix < 0)
                        return 0;
                    total = prefix + total;
                    x = x / 10;
                    if (total >= maxPositive || total < 0)
                        return 0;

                }
                return (int)total;
            }
            else
            {
                while (x < 0)
                {
                    lastDigit = -1 * (x % 10);
                    prefix = lastDigit * (long)Math.Pow(10, exponent--);
                    if (prefix >= maxNegative || prefix < 0)
                        return 0;
                    total = -1 * prefix + total;

                    x = x / 10;
                    if (total <= Int32.MinValue)
                        return 0;

                }
            }



            return (int)total;

        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root is null) return new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> response = new List<int>();

            TreeNode node = root;
            while (node != null || stack.Count != 0)
            {
                while (node is not null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                }

                response.Add(node.val);


                node = node.right;


            }

            return response;
        }

        //Construct String from Binary Tree, pruning extra parenthesis
        public string Tree2str(TreeNode root)
        {
            string response = Tree2strHelper(root);
            response = response.Substring(1, response.Length - 2);

            string final = PostProcessResponse(response, lastStable: response);
            return final;

        }
        public static string PostProcesser(string response)
        {
            string final = PostProcessResponse(response, lastStable: response);
            return final;
        }
        private static string PostProcessResponse(string response, string lastStable)
        {
            string candidate = response.Replace("()()", "");
            candidate = candidate.Replace(")())", "))");
            candidate = candidate.EndsWith("()") ? candidate.Substring(0, candidate.Length - 2) : candidate;
            if (candidate.GetHashCode().CompareTo(lastStable.GetHashCode()) == 0)
            {
                return lastStable;
            }
            return PostProcessResponse(candidate, response);
        }

        public string Tree2strHelper(TreeNode current)
        {
            if (current is null) return ")";


            else
            {
                string formed = $"({current.val}";
                if (current.left is null) formed += "(";
                formed += Tree2strHelper(current.left);
                if (current.right is null) formed += "(";
                formed += Tree2strHelper(current.right);

                return formed + ")";


            }
        }
        public TreeNode PruneTree(TreeNode root)
        {
            return HasOnes(root) ? root : null;
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



            return root.val == 1 || leftHasOnes || rightHasOnes;
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

        public static bool HasPathUndirectedGraph<T>(UndirectedGraph<T> undirectedGraph, T source, T destination)
        {
            return HasPathUndirectedGraphHelper(undirectedGraph, source, destination, new Dictionary<T, bool>());
        }
        public static bool HasPathUndirectedGraphHelper<T>(UndirectedGraph<T> undirectedGraph, T source, T destination, Dictionary<T, bool> visited)
        {
            if (source.GetHashCode().CompareTo(destination.GetHashCode()) == 0)
            {
                return true;
            }
            foreach (var neighborg in undirectedGraph.AdjacencyList[source])
            {
                if (!visited.ContainsKey(neighborg))
                {
                    visited.Add(neighborg, true);
                    bool hasPath = HasPathUndirectedGraphHelper(undirectedGraph, neighborg, destination, visited);
                    if (hasPath)
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        private static bool NotRepeatedCharacters(string concatenationCandidate)
        {
            return concatenationCandidate.Distinct().Count() == concatenationCandidate.Length;
        }
    }
}
