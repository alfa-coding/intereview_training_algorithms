using System.Collections.Generic;

namespace Algorithms.Library
{
    
    /**
    * // This is the interface that allows for creating nested lists.
    * // You should not implement it, or speculate about its implementation
    **/


    public interface INestedInteger {
 
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      IList<INestedInteger> GetList();
  }

    public class NestedIterator
    {

        Queue<int> queue = new();

        public NestedIterator(IList<INestedInteger> nestedList)
        {
            FillQueue(nestedList);
        }

        public bool HasNext()
        {
            return queue.Count != 0;
        }

        public int Next()
        {
            return queue.Dequeue();
        }

        private void FillQueue(IList<INestedInteger> nestedList)
        {
            if (nestedList == null) return;

            foreach (var item in nestedList)
            {
                if (item.IsInteger())
                    this.queue.Enqueue(item.GetInteger());
                else
                {
                    FillQueue(item.GetList());
                }
            }
        }
    }

    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}