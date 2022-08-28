using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class AVLTree<T> : BST<T>, IEnumerable<T>, IEnumerable where T : IComparable<T>
    {
        private BSTNode<T> root;

        public override void Insert(T data)
        {
            if (root is null)
            {
                this.root = new BSTNode<T>(null, null, data);
            }
            else
            {

            }
        }

        public static BSTNode<T> Balance(BSTNode<T> node)
        {
            if (node.BalanceFactor < 0)
            {
                if (node.Left.BalanceFactor > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                //left side is heavier than righ side
                return RotateRight(node);
            }
            else if (node.BalanceFactor > 0)
            {
                if (node.Right.BalanceFactor < 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                //right side is heavier than left side
                return RotateLeft(node);
            }
            else
                //is already balanced
                return node;
        }

        private static BSTNode<T> RotateRight(BSTNode<T> node)
        {
            BSTNode<T> rightTmp = new BSTNode<T>(null, null, node.Data);
            node.Left.Right = rightTmp;
            return node.Left;
        }

        private static BSTNode<T> RotateLeft(BSTNode<T> node)
        {
            BSTNode<T> leftTmp = new BSTNode<T>(null, null, node.Data);
            node.Right.Left = leftTmp;
            return node.Right;
        }
    }


}