using System.Collections.Generic;
using System.Linq;
using System;

namespace Algorithms.Library
{
    public class SimetricTreeMirror
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root is null) return true;

            return IsMirror(root.left, root.right);
        }
        public bool IsMirror(TreeNode a, TreeNode b)
        {
            if (a == null && b == null) return true;

            if (a == null || b == null) return false;
            if (a != null && b != null)
            {
                if (a.val == b.val && IsMirror(a.left, b.right) && IsMirror(a.right, b.left)) return true;

            }
            return false;

        }
    }
}