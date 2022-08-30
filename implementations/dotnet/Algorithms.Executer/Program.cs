using System;
using System.Collections.Generic;
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

            PrintVector(myAVL,"Printing elements in AVL");
            #endregion

            #region ConcatenationExcersise

            string [] words1 = {"d","c","b"};
            int longestConctatResult1 = Training.LongestConctatString(words1);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult1}, expected:3");

            string [] words2 = {"ab","b","cd","ef"};
            int longestConctatResult2 = Training.LongestConctatString(words2);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult2}, expected:6");

            string [] words3 = {"ab","bruto","cd","ef"};
            int longestConctatResult3 = Training.LongestConctatString(words3);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult3}, expected:9");

            string [] words4 = {"ab","ab","ab","ab"};
            int longestConctatResult4 = Training.LongestConctatString(words4);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult4}, expected:0");

            string [] words5 = {"ban","ryan","andy","dian"};
            int longestConctatResult5 = Training.LongestConctatString(words5);
            System.Console.WriteLine($"The longest cancat is: {longestConctatResult5}, expected:0");

            #endregion

            #region TargetSum

            int [] numbers = {9,1,7,3,2};
            var resultingPositions = Training.TargetSum(numbers,11);
            System.Console.WriteLine($"The resulting positions are: {resultingPositions.Item1} & {resultingPositions.Item2}");

            int [] numbers2 = {3,2,4};
            var resultingPositions2 = Training.TargetSum(numbers2,6);
            System.Console.WriteLine($"The resulting positions are: {resultingPositions2.Item1} & {resultingPositions2.Item2}");

             int [] numbers3 = {3,3};
            var resultingPositions3 = Training.TargetSum(numbers3,6);
            System.Console.WriteLine($"The resulting positions are: {resultingPositions3.Item1} & {resultingPositions3.Item2}");

            #endregion



            #endregion
            System.Console.WriteLine("Bye World");

        }
    }
}
