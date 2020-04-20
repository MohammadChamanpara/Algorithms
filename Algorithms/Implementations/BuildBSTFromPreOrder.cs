using System;
using System.Collections;
using System.Collections.Generic;

class BuildBSTFromPreOrder
{
    public static void Run()
    {
        Console.WriteLine(new Solution().BstFromPreorder(new int[] { 8, 5, 1, 7, 10, 12 }));
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder.Length == 0)
                return null;
            TreeNode root = null;
            for (int i = 0; i < preorder.Length; i++)
                root = Add2Tree(preorder[i], root);

            return root;
        }

        private TreeNode Add2Tree(int number, TreeNode parent)
        {
            if (parent == null)
                return new TreeNode(number);

            if (number < parent.val)
                parent.left = Add2Tree(number, parent.left);
            else
                parent.right = Add2Tree(number, parent.right);

            return parent;
        }
    }
}