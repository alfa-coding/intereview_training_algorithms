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
            this.CounterData=1;
        }

        public bool IsLeaf { get => (Right is null && Left is null); }

        public int Height
        {
            get
            {
                if ((this is not null) && this.IsLeaf)
                {
                    return 1;
                }
                return Math.Max(this.Right.Height,this.Left.Height)+1;
            }
        }

        public int CounterData { get; internal set; }
    }
    public class BST<T> : IEnumerable<T>, IEnumerable where T: IComparable<T>
    {
        BSTNode<T> root;

        public int Height { get=>root.Height; }

        public void Insert(T data)
        {
            if (root is null)
            {
                root = new BSTNode<T>(null,null,data);
            }
            else
            {
                BSTNode<T> tmp = root;
                int insertionIndicator = 0;
                while (tmp!=null)
                {
                    if (tmp.Left is not null && tmp.Left.Data.CompareTo(data)>0)
                    {
                        tmp=tmp.Left;
                        insertionIndicator = -1;
                    }
                    else if (tmp.Right is not null && tmp.Right.Data.CompareTo(data)>0)
                    {
                        tmp=tmp.Right;
                        insertionIndicator = 1;

                    }
                    else
                    {
                        if (tmp.Data.CompareTo(data)==0)
                        {
                            tmp.CounterData++;
                            break;
                        }
                    }
                }

                if (insertionIndicator<0)
                {
                    tmp.Left = new BSTNode<T>(null,null,data);
                }
                else if (insertionIndicator>0)
                {
                    tmp.Right = new BSTNode<T>(null,null,data);
                }
                else
                {
                    //
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}