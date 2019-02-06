using System;
using System.Collections.Generic;
using System.Text;

namespace Study.BinaryTree
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public virtual T Value { get; set; }
        public virtual TreeNode<T> Left { get; set; }
        public virtual TreeNode<T> Right { get; set; }
        public virtual TreeNode<T> Parent { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
        }

        public virtual bool IsLeaf
        {
            get
            {
                if (Left == null && Right == null)
                    return true;
                return false;

            }
            private set {}
        }

        public virtual bool HasOnlyLeftChild
        {
            get
            {
                if (Left != null && Right == null)
                    return true;
                return false;

            }
            private set {}
        }

        public virtual bool HasOnlyRightChild
        {
            get
            {
                if (Left == null && Right != null)
                    return true;
                return false;

            }
            private set { IsLeaf = value; }
        }

        public virtual bool IsLeftChild
        {
            get { return this.Parent != null && this.Parent.Left == this; }
        }

        public virtual bool IsRightChild
        {
            get { return this.Parent != null && this.Parent.Right == this; }
        }
    }


}
