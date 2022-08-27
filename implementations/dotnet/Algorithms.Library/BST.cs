using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class BSTNode<T>
    {
        public T Data { get; set; }
        public BSTNode<T> Left { get; set; }
        public BSTNode<T> Right { get; set; }
        public BSTNode(BSTNode<T> left, BSTNode<T> right, T data)
        {
            Left = left;
            Right = right;
            Data = data;
            this.CounterData = 1;
        }

        public bool IsLeaf { get => (Right is null && Left is null); }

        public int Height
        {
            get
            {
                if (this is null)
                {
                    return 0;
                }
                if (this.IsLeaf)
                {
                    return 1;
                }
                int leftH = this.Left is not null ? this.Left.Height : 0;
                int rightH = this.Right is not null ? this.Right.Height : 0;

                return Math.Max(leftH, rightH) + 1;
            }
        }

        public int CounterData { get; internal set; }
    }
    public class BST<T> : IEnumerable<T>, IEnumerable where T : IComparable<T>
    {
        BSTNode<T> root;

        public int Height { get => root.Height; }

        public void Insert(T data)
        {
            if (root is null)
            {
                root = new BSTNode<T>(null, null, data);
            }
            else
            {
                BSTNode<T> tmp = root;
                while (tmp != null)
                {
                    if (tmp.Data.CompareTo(data) > 0)
                    {
                        //directly inserting on the left, or recursively 
                        //going left.
                        if (tmp.Left is null)
                        {
                            tmp.Left = new BSTNode<T>(null, null, data);
                            break;
                        }
                        else
                        {
                            tmp = tmp.Left;
                        }
                    }
                    else if (tmp.Data.CompareTo(data) < 0)
                    {
                        if (tmp.Right is null)
                        {
                            tmp.Right = new BSTNode<T>(null, null, data);
                            break;
                        }
                        else
                        {
                            tmp = tmp.Right;
                        }

                    }
                    else
                    {
                        if (tmp.Data.CompareTo(data) == 0)
                        {
                            tmp.CounterData++;
                            break;
                        }
                    }
                }


            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<BSTNode<T>> elements = InOrder();
            foreach (var item in elements)
            {
                yield return item.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


         private List<BSTNode<T>> InOrder()
        {
            List<BSTNode<T>> response = new List<BSTNode<T>>();
            InOrderHelper(this.root, response);
            return response;
        }
        private void InOrderHelper(BSTNode<T> node, List<BSTNode<T>> all)
        {
            if (node is null)
            {
                return;
            }
            if (node.Left is not null)
            {
                InOrderHelper(node.Left, all);
            }
            if (node is not null)
            {
                all.Add(node);
            }
            if (node.Right is not null)
            {
                InOrderHelper(node.Right, all);
            }
        }
    }

     
    
}