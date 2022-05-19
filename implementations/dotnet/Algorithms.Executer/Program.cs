using System;
using System.Collections.Generic;
using Algorithms.Library;

namespace Algorithms.Executer
{
    class Program
    {
        public static void PrintVector<T>(IEnumerable<T> elements)
        {
            System.Console.WriteLine("---------");

            foreach (var item in elements)
            {
                System.Console.Write($"{item} ");
            }
            System.Console.WriteLine("\n---------");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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

            System.Console.WriteLine("Bye World");

        }
    }
}
