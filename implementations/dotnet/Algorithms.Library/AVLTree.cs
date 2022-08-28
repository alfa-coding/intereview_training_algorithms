using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class AVLTree<T> : BST<T>, IEnumerable<T>, IEnumerable where T : IComparable<T>
    {

        public override void Insert(T data)
        {
            if (this.root is null)
            {
                this.root = new BSTNode<T>(null, null, data);
            }
            else
            {
                this.root = InsertHelper(this.root, data);
            }
        }

        private BSTNode<T> InsertHelper(BSTNode<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left is null)
                    node.Left = new BSTNode<T>(null, null, data);
                else
                    node.Left = InsertHelper(node.Left, data);
            }
            else if (data.CompareTo(node.Data) > 0)
            {
                if (node.Right is null)
                    node.Right = new BSTNode<T>(null, null, data);
                else
                    node.Right = InsertHelper(node.Right, data);
            }
            else
            //case (node.Data.CompareTo(data)==0)
            {
                node.CounterData++;
            }

            node = Balance(node);

            return node;

        }

        public static BSTNode<T> Balance(BSTNode<T> node)
        {
            if (node.BalanceFactor < 0)
            {
                if (node.Left.BalanceFactor > 0)
                {
                    node.Left = RotateRightToLeft(node.Left);
                }

                //left side is heavier than righ side
                return RotateLeftToRight(node);
            }
            else if (node.BalanceFactor > 1)
            {
                if (node.Right.BalanceFactor < 0)
                {
                    node.Right = RotateLeftToRight(node.Right);
                }

                //right side is heavier than left side
                return RotateRightToLeft(node);
            }
            else
                //is already balanced
                return node;
        }

        public static BSTNode<T> RotateRightToLeft(BSTNode<T> node)
        {
            BSTNode<T> exRoot = new BSTNode<T>(null, null, node.Data);
            exRoot.Left = node.Left;

            //leftchild of Root RightChild
            BSTNode<T> centerNode = node.Right.Left??null;
            if (centerNode is null)
            {
                //the new center node is the old root
                node.Right.Left = exRoot;
            }
            else
            {

                exRoot.Right = centerNode;
                node.Right.Left = exRoot;
            }
            return node.Right;
        }

        public static BSTNode<T> RotateLeftToRight(BSTNode<T> node)
        {
            BSTNode<T> exRoot = new BSTNode<T>(node.Data);
            exRoot.Right = node.Right;

            //rightchild of Root LeftChild
            BSTNode<T> centerNode = node.Left.Right??null;

            if (centerNode is null)
            {
                //the new center node is the old root
                node.Left.Right = exRoot;
            }
            else
            {
                exRoot.Left = centerNode;
                node.Left.Right = exRoot;

            }
            return node.Left;
        }
    }


}