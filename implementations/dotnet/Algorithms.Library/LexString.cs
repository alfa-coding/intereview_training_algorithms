using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class LexString
    {
        private string response="";
        public string SmallestFromLeaf(TreeNode root)
        {

            DFS(root, formed: (char)(root.val + 97) + "");
            return response;
        }

        public void DFS(TreeNode root, string formed)
        {

            if (root is null) return;
            if (root.left == null && root.right == null)
            {
                if (response == "")
                {
                    response = formed;
                    return;
                }
                if (formed.CompareTo(response) < 0)
                {
                    response = formed;
                }
            }
            if (root.left != null)
                DFS(root.left, (char)(root.left.val + 97) + formed);
            if (root.right != null)
                DFS(root.right, (char)(root.right.val + 97) + formed);

        }
    }
}