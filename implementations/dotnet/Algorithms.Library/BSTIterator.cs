using System.Collections.Generic;

namespace Algorithms.Library
{
    public class BSTIterator
    {
        int index = -1;
        List<int> values = new();
        public BSTIterator(TreeNode root)
        {
            TraverseANDFill(root);
        }
        private void TraverseANDFill(TreeNode root)
        {
            if (root == null) return;
            TraverseANDFill(root.left);
            values.Add(root.val);
            TraverseANDFill(root.right);
        }

        public int Next()
        {
            return values[++index];
        }

        public bool HasNext()
        {
            return values.Count != 0 && index + 1 < values.Count;
        }
    }
}