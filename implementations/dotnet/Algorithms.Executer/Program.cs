using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Library;

namespace Algorithms.Executer
{
    class Program
    {
        public static void PrintVector<T>(IEnumerable<T> elements, string message = "")
        {
            System.Console.WriteLine($"----{message}-----");

            foreach (var item in elements)
            {
                System.Console.Write($"{item} ");
            }
            System.Console.WriteLine("\n---------");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region RegularList

            RegularList<int> myRegularList = new RegularList<int>() { 5, 7, 9, 10 };
            PrintVector(myRegularList);

            myRegularList.Add(4);
            PrintVector(myRegularList);

            myRegularList.Insert(2, 80);

            PrintVector(myRegularList);

            myRegularList.Remove(7);

            PrintVector(myRegularList);

            myRegularList.RemoveAt(3);

            PrintVector(myRegularList);
            #endregion

            #region RegularLinkedList

            RegularLinkedList<string> names = new RegularLinkedList<string>()
            {
                "juan","sasha","claudia"
            };
            PrintVector(names, message: "LinkedList add at ctor time");

            names.Add("dimas");
            PrintVector(names, message: "LinkedList, add function");

            names.Add("pedro");
            PrintVector(names, message: "LinkedList, add function");

            names.Remove("claudia");
            PrintVector(names, message: "LinkedList, remove function");

            names.Add("jonathan");
            PrintVector(names, message: "LinkedList, add function");

            names.AddFirst("Shivam");
            PrintVector(names, message: "LinkedList, addfirst function");




            #endregion

            #region TRIE TREE
            TRIETree trie = new TRIETree();

            trie.AddWord("andy");
            trie.AddWord("adriana");
            trie.AddWord("and");

            trie.AddWord("dimas");
            trie.AddWord("diana");

            bool result = trie.ContainsWord("dimas");
            System.Console.WriteLine(result);


            var wordsAlphabetically = trie.ListAlphabetically();

            PrintVector(wordsAlphabetically, "words contained inside the TRIE");


            var sufixes = trie.SufixesOf("a");

            PrintVector(sufixes, "sufixes of 'a' ");
            #endregion

            #region  BST

            BST<int> binarySearchTree = new BST<int>();
            binarySearchTree.Insert(5);

            binarySearchTree.Insert(3);
            binarySearchTree.Insert(7);

            binarySearchTree.Insert(4);
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(15);

            binarySearchTree.Insert(3);

            System.Console.WriteLine($"BST heigh is: {binarySearchTree.Height}");

            System.Console.WriteLine($"BST Balace Factor is: {binarySearchTree.BalanceFactor}");

            PrintVector(binarySearchTree, "Elements in order from BST");

            #endregion

            #region TestingBasicRotation
            BSTNode<int> i1a = new BSTNode<int>(null, null, 1);
            BSTNode<int> i1 = new BSTNode<int>(i1a, null, 3);
            BSTNode<int> parentA = new BSTNode<int>(i1, null, 5);

            BSTNode<int> rotatedToRight = AVLTree<int>.Balance(parentA);
            System.Console.WriteLine(rotatedToRight.Data);

            BSTNode<int> r1a = new BSTNode<int>(null, null, 9);
            BSTNode<int> r1 = new BSTNode<int>(null, r1a, 7);
            BSTNode<int> parentB = new BSTNode<int>(null, r1, 5);

            BSTNode<int> rotatedToLeft = AVLTree<int>.Balance(parentB);
            System.Console.WriteLine(parentB.Data);
            #endregion

            #region TestingDoubleRotation
            BSTNode<int> iib = new BSTNode<int>(null, null, 3);
            BSTNode<int> ii = new BSTNode<int>(null, iib, 1);
            BSTNode<int> parentC = new BSTNode<int>(ii, null, 5);

            BSTNode<int> doubleBalancedLeft = AVLTree<int>.Balance(parentC);
            System.Console.WriteLine(doubleBalancedLeft.Data);

            BSTNode<int> rrb = new BSTNode<int>(null, null, 7);
            BSTNode<int> rr = new BSTNode<int>(rrb, null, 9);
            BSTNode<int> parentD = new BSTNode<int>(null, rr, 5);

            BSTNode<int> doubleBalancedRight = AVLTree<int>.Balance(parentD);
            System.Console.WriteLine(doubleBalancedRight.Data);
            #endregion


            #region AVL testing

            AVLTree<int> myAVL = new AVLTree<int>();
            for (int i = 0; i < 20; i++)
            {
                myAVL.Insert(i);
            }

            PrintVector(myAVL, "Printing elements in AVL");
            #endregion

            #region ConcatenationExcersise

            string[] words1 = { "d", "c", "b" };
            int longestConctatResult1 = Training.LongestConctatString(words1);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult1}, expected:3");

            string[] words2 = { "ab", "b", "cd", "ef" };
            int longestConctatResult2 = Training.LongestConctatString(words2);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult2}, expected:6");

            string[] words3 = { "ab", "bruto", "cd", "ef" };
            int longestConctatResult3 = Training.LongestConctatString(words3);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult3}, expected:9");

            string[] words4 = { "ab", "ab", "ab", "ab" };
            int longestConctatResult4 = Training.LongestConctatString(words4);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult4}, expected:0");

            string[] words5 = { "ban", "ryan", "andy", "dian" };
            int longestConctatResult5 = Training.LongestConctatString(words5);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult5}, expected:0");

            #endregion

            #region TargetSum

            int[] numbers = { 9, 1, 7, 3, 2 };
            var resultingPositions = Training.TargetSum(numbers, 11);
            System.Console.WriteLine($"The resulting positions are: {resultingPositions.Item1} & {resultingPositions.Item2}");

            int[] numbers2 = { 3, 2, 4 };
            var resultingPositions2 = Training.TargetSum(numbers2, 6);
            System.Console.WriteLine($"The resulting positions are: {resultingPositions2.Item1} & {resultingPositions2.Item2}");

            int[] numbers3 = { 3, 3 };
            var resultingPositions3 = Training.TargetSum(numbers3, 6);
            System.Console.WriteLine($"The resulting positions are: {resultingPositions3.Item1} & {resultingPositions3.Item2}");

            #endregion

            #region CalculateRain 

            System.Console.WriteLine("----------Calculating Rain---------------");

            int[] walls1 = { 0 };
            int amount1 = Training.CalculateRain(walls1);
            System.Console.WriteLine($"For walls 1 expected: 0, got {amount1}");

            int[] walls2 = { 0, 1 };
            int amount2 = Training.CalculateRain(walls2);
            System.Console.WriteLine($"For walls 2 expected: 0, got {amount2}");

            int[] walls3 = { 1, 0 };
            int amount3 = Training.CalculateRain(walls3);
            System.Console.WriteLine($"For walls 3 expected: 0, got {amount3}");

            //valley
            int[] walls4 = { 1, 0, 1 };
            int amount4 = Training.CalculateRain(walls4);
            System.Console.WriteLine($"For walls 4 expected: 1, got {amount4}");


            //peek
            int[] walls5 = { 1, 2, 1 };
            int amount5 = Training.CalculateRain(walls5);
            System.Console.WriteLine($"For walls 5 expected: 0, got {amount5}");

            //basic hypotesis
            int[] walls6 = { 2, 1, 0, 3 };
            int amount6 = Training.CalculateRain(walls6);
            System.Console.WriteLine($"For walls 6 expected: 3, got {amount6}");

            //basic hypotesis
            int[] walls7 = { 3, 1, 0, 2, 0, 4 };
            int amount7 = Training.CalculateRain(walls7);
            System.Console.WriteLine($"For walls 7 expected: 9, got {amount7}");

            //basic hypotesis with center
            int[] walls8 = { 3, 1, 0, 9, 0, 4 };
            int amount8 = Training.CalculateRain(walls8);
            System.Console.WriteLine($"For walls 8 expected: 9, got {amount8}");

            //real testCase left
            int[] walls9 = { 0, 1, 0, 1, 2, 2, 1, 1, 4 };
            int amount9 = Training.CalculateRain(walls9);
            System.Console.WriteLine($"For walls 9 expected: 3, got {amount9}");

            //real testCase right
            int[] walls10 = { 4, 3, 1, 0, 2, 1, 5 };
            int amount10 = Training.CalculateRain(walls10);
            System.Console.WriteLine($"For walls 10 expected: 13, got {amount10}");

            //real testCase full
            int[] walls11 = { 0, 1, 0, 1, 2, 2, 1, 1, 4, 3, 1, 0, 2, 1, 5 };
            int amount11 = Training.CalculateRain(walls11);
            System.Console.WriteLine($"For walls 11 expected: 16, got {amount11}");

            //real testCase video
            int[] walls12 = { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 };
            int amount12 = Training.CalculateRain(walls12);
            System.Console.WriteLine($"For walls 12 expected: 8, got {amount12}");

            //from leetcode
            int[] walls13 = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int amount13 = Training.CalculateRain(walls13);
            System.Console.WriteLine($"For walls 13 expected: 6, got {amount13}");
            #endregion

            #region Typed Out Strings

            System.Console.WriteLine("-----------Typed Out Strings-----------");
            List<Tuple<string, string, bool>> pairs = new List<Tuple<string, string, bool>>()
            {
                //new Tuple<string, string,bool>("ab#z","az#z",true),
                //new Tuple<string, string,bool>("abc#d","acc#c",false),
                //new Tuple<string, string,bool>("x#y#z#","a#",true),
                //new Tuple<string, string,bool>("a###b","b",true),
                //new Tuple<string, string,bool>("Ab#z","ab#z",false),
                new Tuple<string, string,bool>("isfcow#","isfco#w#",false)
            };

            foreach (var item in pairs)
            {
                Console.WriteLine($"For pair {item.Item1}&{item.Item2}" +
                                  $" expected: {item.Item3}," +
                                  $" got {Training.TypedOutStrings(item.Item1, item.Item2)}");
            }
            #endregion


            #region TreePreOrderParenthesis

            System.Console.WriteLine("-----------Simplified Parenthesis Strings-----------");
            List<Tuple<string, string>> parenthesis = new List<Tuple<string, string>>()
            {
             new Tuple<string, string>("1(2(3(4(5(6()())())())())())()","1(2(3(4(5(6)))))"),
             new Tuple<string, string>("1(2(4()())())(3()())","1(2(4))(3)"),
             new Tuple<string, string>("1(2()(4()()))(3()())" ,"1(2()(4))(3)"),

            };

            foreach (var item in parenthesis)
            {
                string resulted = Training.PostProcesser(item.Item1);
                System.Console.WriteLine($"For 1st {item.Item1}" +
                                  $" expected: {item.Item2}," +
                                  $" got {resulted}, which is correct:{resulted == item.Item2}");
            }

            #endregion

            #region Reversing Numbers
            System.Console.WriteLine("-----------Reversing numbers-----------");
            List<Tuple<int, int>> pairOfNumbers = new List<Tuple<int, int>>()
            {
             new Tuple<int, int>(1534236469,0),
             new Tuple<int, int>(-2147483412,-2143847412),
             new Tuple<int, int>(1463847412,2147483641)


            };

            foreach (var item in pairOfNumbers)
            {
                int resulted = Training.Reverse(item.Item1);
                System.Console.WriteLine($"For 1st {item.Item1}" +
                                  $" expected: {item.Item2}," +
                                  $" got {resulted}, which is correct:{resulted == item.Item2}");
            }

            #endregion

            #region DirectedAsyclicGraph

            DirectedAsyclicGraph<char> graph = new DirectedAsyclicGraph<char>()
            {
                AdjacencyList = new Dictionary<char, List<char>>()
                {
                    {'a',new List<char>{'c','b'}},
                    {'b',new List<char>{'d'}},
                    {'c',new List<char>{'e'}},
                    {'d',new List<char>{'f'}},
                    {'e',new List<char>()},
                    {'f',new List<char>()},
                }
            };

            System.Console.WriteLine("--------DFS Recursively-------");
            Training.DFSRecursive('a', graph);
            System.Console.WriteLine("--------DFS Iteratively-------");
            Training.DFSStackBased('a', graph);
            System.Console.WriteLine("--------BFS Iteratively-------");
            Training.BFSQueueBased('a', graph);


            #endregion

            #region UndirectedGraphWithEdges
            List<Tuple<char, char>> edges = new List<Tuple<char, char>>()
            {
                new Tuple<char, char>('i','j'),
                new Tuple<char, char>('k','i'),
                new Tuple<char, char>('m','k'),
                new Tuple<char, char>('k','l'),
                new Tuple<char, char>('o','n'),

            };
            UndirectedGraph<char> undirectedGraph = new UndirectedGraph<char>(edges, true);
            bool isPath = Training.HasPathUndirectedGraph(undirectedGraph, 'j', 'm');
            System.Console.WriteLine($"Has path, returned {isPath}, expected {true}");
            #endregion

            #region LengthLongestSubStr
            System.Console.WriteLine("------------LengthLongestSubStr---------------");

            int gottenLength = Training.LengthOfLongestSubstring("dvdf");
            System.Console.WriteLine($"for {"dvdf"} got: {gottenLength},expected {3}");

            #endregion

            #region MaxProfit
            System.Console.WriteLine("----------MaxProfit-----------MaxProfit");
            List<int> case1 = new List<int>() { 2, 4, 1 };
            int case1Exp = Training.MaxProfit(2, case1.ToArray());
            System.Console.WriteLine($"for {"2,4,1"} got: {case1Exp},expected {2}");

            List<int> case2 = new List<int>() { 3, 2, 6, 5, 0, 3 };
            int case2Exp = Training.MaxProfit(2, case2.ToArray());
            System.Console.WriteLine($"for {"3,2,6,5,0,3"} got: {case2Exp},expected {7}");

            #endregion

            #region TownJudge
            int gottenJudge = Training.FindJudge(2, new int[][] { new int[] { 1, 2 } });
            System.Console.WriteLine($"for {"{{1,2}}"} got: {gottenJudge},expected {2}");

            #endregion

            #region MinRemoveToMakeValid
            System.Console.WriteLine("------------MinRemoveToMakeValid----------");
            string message = "lee(t(c)o)de)";
            string gottenRemove = Training.MinRemoveToMakeValid(message);
            System.Console.WriteLine($"Min () remove, for {message} returned {gottenRemove}");
            #endregion

            #region QuickSort
            System.Console.WriteLine("------------QuickSort----------");
            int[] numeros = { 4, 57, 8, 92, 1, 23, 6, 5, 45, 98, 15 };
            Training.QuickSort(numeros);
            PrintVector(numeros, "This is the ordered array using quicksort");
            #endregion

            #region Duplicate
            string[] paths = new string[]
            {
                "root/a 1.txt(abcd) 2.txt(efgh)",
                "root/c 3.txt(abcd)",
                "root/c/d 4.txt(efgh)",
                "root 4.txt(efgh)"
            };
            var response = Training.FindDuplicate(paths);
            #endregion

            #region SmartTRIE
            SmartTRIETree smartTRIE = new SmartTRIETree();

            smartTRIE.AddWord("andy");
            smartTRIE.AddWord("adriana");
            smartTRIE.AddWord("are");

            smartTRIE.AddWord("dimas");
            smartTRIE.AddWord("diana");
            smartTRIE.AddWord("dinerito");
            smartTRIE.AddWord("dimasito");
            smartTRIE.AddWord("dimasino");

            smartTRIE.AddWord("bad");
            smartTRIE.AddWord("mad");
            smartTRIE.AddWord("pad");

            smartTRIE.AddWord("bla");




            bool resultSmartBase = smartTRIE.ContainsWord("d");
            System.Console.WriteLine($"got:{resultSmartBase},expects:false");//matches nothing


            bool resultSmart = smartTRIE.ContainsWord("dimas");
            System.Console.WriteLine($"got:{resultSmart},expects:true");//matches fully

            bool resultSmart2 = smartTRIE.ContainsWord("dimk");
            System.Console.WriteLine($"got:{resultSmart2},expects:false");//matches until dim,then k fails

            bool resultSmart3 = smartTRIE.ContainsWord("di...");
            System.Console.WriteLine($"got:{resultSmart3},expects:true"); //matches dimas/diana

            bool resultSmart4 = smartTRIE.ContainsWord("di....to");
            System.Console.WriteLine($"got:{resultSmart4},expects:true"); //matches dimasito/dinerito

            bool resultSmart5 = smartTRIE.ContainsWord(".ad");
            System.Console.WriteLine($"got:{resultSmart5},expects:true"); //matches bad/mad/pad

            bool resultSmart6 = smartTRIE.ContainsWord("..a");
            System.Console.WriteLine($"got:{resultSmart6},expects:true"); //matches bla

            bool resultSmart7 = smartTRIE.ContainsWord(".a.");
            System.Console.WriteLine($"got:{resultSmart7},expects:true"); //matches bad/mad/pad

            bool resultSmart8 = smartTRIE.ContainsWord(".ag");
            System.Console.WriteLine($"got:{resultSmart8},expects:false"); //matches bad/mad/pad



            #endregion

            #region CircularQueue

            MyCircularQueue mcq = new MyCircularQueue(8);
            Console.WriteLine(mcq.EnQueue(3));
            Console.WriteLine(mcq.EnQueue(9));
            Console.WriteLine(mcq.EnQueue(5));
            Console.WriteLine(mcq.EnQueue(0));

           

            Console.WriteLine(mcq.DeQueue());
            Console.WriteLine(mcq.DeQueue());

            Console.WriteLine(mcq.IsEmpty());
            Console.WriteLine(mcq.IsEmpty());


            System.Console.WriteLine(mcq.Rear());
            System.Console.WriteLine(mcq.Rear());
            Console.WriteLine(mcq.DeQueue());


            #endregion

            #region Chalk problem
            int whereToStop = Training.ChalkReplacer(new int[]{5,1,5},22);
            System.Console.WriteLine(whereToStop);
            int whereToStop2 = Training.ChalkReplacer(new int[]{3,4,1,2},25);
            System.Console.WriteLine(whereToStop2);
            #endregion
            System.Console.WriteLine("Bye World");

        }
    }
}
