namespace Algorithms.Library
{
    public class ConvertToSUPERGTS
    {
        public TreeNode ConvertBST(TreeNode root)
        {
            Fill(root);
            return root;
        }

        private int Fill(TreeNode root, int acc = 0)
        {
            if (root == null) return acc;
            int right = Fill(root.right, acc);
            int left = Fill(root.left, root.val + right);
            root.val = root.val + right;
            return left;

        }
    }
}