using System.Runtime.Intrinsics.X86;

namespace LeetCodeStudyPlanLevel1
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    /// <summary>
    /// Definition for a binary tree node.
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    internal class TreeClass
    {
        /// <summary>
        /// 589. N-ary Tree Preorder Traversal
        /// https://leetcode.com/problems/n-ary-tree-preorder-traversal/?envType=study-plan&id=level-1
        ///
        /// Given the root of an n-ary tree, return the preorder traversal of its nodes' values.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            // return Preorder1(root);
            return Preorder2(root);
        }

        private List<int> global_result = new List<int>();

        /// <summary>
        /// Recursive solution
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder1(Node root)
        {
            if (root == null) return global_result;
            global_result.Add(root.val);
            if (root.children != null)
            {
                foreach (Node child in root.children)
                {
                    Preorder1(child);
                }
            }
            return global_result;
        }

        /// <summary>
        /// Iterative solution
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder2(Node root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Any())
            {
                Node node = stack.Pop();
                result.Add(node.val);

                if (node.children != null)
                {
                    foreach (Node child in node.children.Reverse())
                        stack.Push(child);
                }
            }
            return result;
        }

        /// <summary>
        /// 102. Binary Tree Level Order Traversal
        ///
        /// https://leetcode.com/problems/binary-tree-level-order-traversal/?envType=study-plan&id=level-1
        /// .
        /// Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
        /// .
        /// Учитывая корень бинарного дерева, верните порядок обхода его значений узлов. (то есть слева направо, уровень за уровнем).
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            return LevelOrder_1(root);
        }

        /// <summary>
        /// Var. 1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder_1(TreeNode root)
        {
            IList<IList<int>> output = new List<IList<int>>();

            if (root == null) return output;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var tmp = new List<int>();
                int level = queue.Count;
                for (int i = 0; i < level; i++)
                {
                    var n = queue.Dequeue();
                    tmp.Add(n.val);

                    if (n.left != null)
                        queue.Enqueue(n.left);
                    if (n.right != null)
                        queue.Enqueue(n.right);
                }

                output.Add(tmp);
            }

            return output;
        }


        /// <summary>
        /// 429. N-ary Tree Level Order Traversal
        /// 
        /// https://leetcode.com/problems/n-ary-tree-level-order-traversal/description/
        /// 
        /// Given an n-ary tree, return the level order traversal of its nodes' values.        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> output = new List<IList<int>>();

            if (root == null) return output;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var tmp = new List<int>();
                int level = queue.Count;
                for (int i = 0; i < level; i++)
                {
                    var n = queue.Dequeue();
                    tmp.Add(n.val);

                    if (n.children != null)
                    {
                        foreach (var ch in n.children)
                        {
                            queue.Enqueue(ch);
                        }
                    }
                }

                output.Add(tmp);
            }

            return output;
        }
    }

    /*
    class MyNode
    {
        int Level { get; set; }
        TreeNode Node { get; set; }

        public MyNode(int level, TreeNode node)
        {
            Level = level;
            Node = node;
        }
    }
    */

}