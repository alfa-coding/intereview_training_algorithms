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

            PrintVector(wordsAlphabetically,"words contained inside the TRIE");
            
            
            var sufixes = trie.SufixesOf("a");

            PrintVector(sufixes,"sufixes of 'a' ");
            #endregion
            
            #region  BST

            BST<int> binarySearchTree = new BST<int>();
            binarySearchTree.Insert(5);

            binarySearchTree.Insert(3);
            binarySearchTree.Insert(7);

            binarySearchTree.Insert(4);
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(15);



            System.Console.WriteLine($"BST heigh is: {binarySearchTree.Height}");

            PrintVector(binarySearchTree,"Elements in order from BST");

            #endregion
            System.Console.WriteLine("Bye World");

        }
    }
}
