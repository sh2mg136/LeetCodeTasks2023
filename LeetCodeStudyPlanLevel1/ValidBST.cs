namespace LeetCodeStudyPlanLevel1
{
    /// <summary>
    /// 98. Validate Binary Search Tree
    /// </summary>
    internal class ValidBST
    {
        // Stack<int> _nodeValues = new Stack<int>();
        private List<int> _nodeValues = new List<int>();

        /// <summary>
        /// 98. Validate Binary Search Tree
        /// https://leetcode.com/problems/validate-binary-search-tree/?envType=study-plan&id=level-1
        /// Given the root of a binary tree, determine if it is a valid binary search tree (BST).
        ///
        /// A valid BST is defined as follows:
        ///
        /// The left subtree of a node contains only nodes with keys less than the node's key.
        /// The right subtree of a node contains only nodes with keys greater than the node's key.
        /// Both the left and right subtrees must also be binary search trees.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            _nodeValues = new List<int>();
            return isValidBST_2(root);
            // return IsValidBST_1(root);
        }

        public bool IsValidBST_1(TreeNode? root)
        {
            if (root == null) return true;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode? pre = null;

            while (root != null || stack.Any())
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();

                if (pre != null && root.val <= pre.val) return false;

                pre = root;
                root = root.right;
            }
            return true;
        }

        /// <summary>
        /// Binary Tree Inorder Traversal
        /// https://leetcode.com/problems/binary-tree-inorder-traversal/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private List<int> InorderTraversal(TreeNode? root)
        {
            List<int> list = new List<int>();
            if (root == null) return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Any())
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                list.Add(root.val);
                root = root.right;
            }
            return list;
        }

        /// <summary>
        /// 230. Kth Smallest Element in a BST
        /// https://leetcode.com/problems/kth-smallest-element-in-a-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int kthSmallest(TreeNode? root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Any())
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (--k == 0) break;
                root = root.right;
            }
            return root?.val ?? 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="root"></param>
        private void inorder(TreeNode root)
        {
            if (root.left != null)
                inorder(root.left);

            if (root != null)
            {
                _nodeValues.Add(root.val);

                if (root.right != null)
                    inorder(root.right);
            }
        }

        private bool isValidBST_2(TreeNode root)
        {
            inorder(root);

            for (int i = 0; i < _nodeValues.Count() - 1; i++)
            {
                if (_nodeValues[i] >= _nodeValues[i + 1]) return false;
            }

            return true;
        }

        /// <summary>
        /// 235. Lowest Common Ancestor of a Binary Search Tree.
        ///
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/?envType=study-plan&id=level-1
        ///
        /// Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.
        ///
        /// According to the definition of LCA on Wikipedia:
        /// “The lowest common ancestor is defined between two nodes p and q as the lowest node in T
        /// that has both p and q as descendants(where we allow a node to be a descendant of itself).”
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // return LowestCommonAncestor_1(root, p, q);
            return LowestCommonAncestor_2(root, p, q);
        }

        /// <summary>
        /// Recoursive
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private TreeNode LowestCommonAncestor_1(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return new TreeNode();

            if (root.left != null && root.val > p.val && root.val > q.val)
                return LowestCommonAncestor_1(root.left, p, q);

            if (root.right != null && root.val < p.val && root.val < q.val)
                return LowestCommonAncestor_1(root.right, p, q);

            return root;
        }

        /// <summary>
        /// 2nd solution
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        TreeNode? LowestCommonAncestor_2(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (root.left != null && root.val > p.val && root.val > q.val)
                    root = root.left;
                else if (root.right != null && root.val < p.val && root.val < q.val)
                    root = root.right;
                else return root;
            }
            return root;
        }
    }
}