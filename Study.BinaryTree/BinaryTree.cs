using System;
using System.Collections;
using System.Collections.Generic;

namespace Study.BinaryTree
{
    public enum TraversalMode
    {
        InorderTraversal,
        PreorderTraversal,
        PostorderTraversal
    }
    public class BinaryTree<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        protected TreeNode<T> _root;
        public virtual int Count { get; private set; }
        protected List<T> _collection = new List<T>();
        public TraversalMode TraversalOrder = TraversalMode.InorderTraversal;

        #region Constructors
        public BinaryTree()
        {

        }

        public BinaryTree(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Insert(item);
        }
        #endregion

        #region Insert
        public virtual void Insert(T value)
        {
            InsertTo(_root, value);
        }

        protected virtual void InsertTo(TreeNode<T> node, T value)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(value);
                Count++;
            }
            else// root != nul
            {
                if (node.Parent == null)
                    node.Parent = _root;

                //Inserting right
                if (value.CompareTo(node.Value) > 0 || value.CompareTo(node.Value) == 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T>(value);
                        node.Right.Parent = node;
                        Count++;
                    }
                    else
                    {
                        InsertTo(node.Right, value);
                    }
                }
                //Inserting left
                else
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>(value);
                        node.Left.Parent = node;
                        Count++;
                    }
                    else
                    {
                        InsertTo(node.Left, value);
                    }
                }
            }
        }
        #endregion

        #region Maximum/Minimum
        public virtual T GetMaxValue()
        {
            if (_root == null)
                throw new BinaryTreeException("Tree is emptry.");
            if (Count == 1)
                return _root.Value;

            TreeNode<T> temp = Max(_root);
            return temp.Value;
        }

        protected TreeNode<T> Max(TreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }
            return Max(node.Right);
        }

        public virtual T GetMinValue()
        {
            if (_root == null)
                throw new BinaryTreeException("Tree is emptry.");
            if (Count == 1)
                return _root.Value;

            TreeNode<T> temp = Min(_root);
            return temp.Value;
        }

        protected TreeNode<T> Min(TreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return Min(node.Left);
        }
        #endregion

        #region Remove
        public virtual bool Remove(T value)
        {
            if (_root == null)
                throw new BinaryTreeException("Tree is emptry. Can't remove value while root is null!");
            return Remove(_root, value);
        }

        public virtual bool Remove(TreeNode<T> node, T value)
        {
            if (node == null)
                return false;
            bool WasRoot = node == _root;
            if (value.CompareTo(node.Value) < 0)
                Remove(node.Left, value);
            else if (value.CompareTo(node.Value) > 0)
                Remove(node.Right, value);
            else if (value.CompareTo(node.Value) == 0)
            {
                if (node.IsLeaf)//Node has no childs
                {
                    if (node.IsLeftChild)
                        node.Parent.Left = null;
                    else if (node.IsRightChild)
                        node.Parent.Right = null;

                    node.Parent = null;
                    node = null;
                    Count--;

                    if (WasRoot)
                        _root = null;
                }
                else if (node.HasOnlyLeftChild)
                {
                    node.Left.Parent = node.Parent;
                    if (WasRoot)
                        _root = node.Left;

                    if (node.IsLeftChild)
                        node.Parent.Left = node.Left;
                    else
                        node.Parent.Right = node.Left;
                    node.Parent = null;
                    node.Left = null;
                    node.Right = null;
                    Count--;
                }
                else if (node.HasOnlyRightChild)
                {
                    node.Right.Parent = node.Parent; 

                    if (WasRoot)
                        _root = node.Right; //update root reference if needed

                    if (node.IsLeftChild) //update the parent's child reference
                        node.Parent.Left = node.Right;
                    else
                        node.Parent.Right = node.Right;
                    node.Parent = null;
                    node.Left = null;
                    node.Right = null;
                    Count--;
                }
                else//Node has 2 childs
                {
                    TreeNode<T> RightTreeMinNode = Min(node.Right);
                    node.Value = RightTreeMinNode.Value;
                    Remove(RightTreeMinNode, RightTreeMinNode.Value);
                }
            }
            return true;
        }
        #endregion

        #region Traversals
        public virtual void InorderTraversal(Action<T> show)
        {
            InorderTraversal(show, _root);
        }

        protected virtual void InorderTraversal(Action<T> show, TreeNode<T> node)
        {
            if (node != null)
            {
                InorderTraversal(show, node.Left);
                show(node.Value);
                InorderTraversal(show, node.Right);
            }
        }
        protected virtual void InorderTraversalCollectionTest(TreeNode<T> node)
        {
            InorderTraversal((value) => _collection.Add(value));
        }
        //Method for Enumerator
        protected void InorderTraversalCollection(TreeNode<T> node)
        {
            if (node != null)
            {
                InorderTraversalCollection(node.Left);
                _collection.Add(node.Value);
                InorderTraversalCollection(node.Right);
            }
        }

        public virtual void PreorderTraversal(Action<T> show)
        {
            PreorderTraversal(show, _root);
        }

        protected virtual void PreorderTraversal(Action<T> show, TreeNode<T> node)
        {
            if (node != null)
            {
                show(node.Value);
                PreorderTraversal(show, node.Left);
                PreorderTraversal(show, node.Right);
            }
        }
        //Method for Enumerator
        protected virtual void PreorderTraversalCollection(TreeNode<T> node)
        {
            if (node != null)
            {
                _collection.Add(node.Value);
                PreorderTraversalCollection(node.Left);
                PreorderTraversalCollection(node.Right);
            }
        }

        public virtual void PostorderTraversal(Action<T> show)
        {
            PostorderTraversal(show, _root);
        }

        protected virtual void PostorderTraversal(Action<T> show, TreeNode<T> node)
        {
            if (node != null)
            {
                PostorderTraversal(show, node.Left);
                PostorderTraversal(show, node.Right);
                show(node.Value);
            }
        }
        //Method for Enumerator
        protected virtual void PostorderTraversalCollection(TreeNode<T> node)
        {
            if (node != null)
            {
                PostorderTraversalCollection(node.Left);
                PostorderTraversalCollection(node.Right);
                _collection.Add(node.Value);
            }
        }
        #endregion

        #region Search/Contains

        protected virtual TreeNode<T> FindElement(TreeNode<T> node, T value)
        {
            /*if (value.CompareTo(node.value) == 0) 
                return node;
            else if (value.CompareTo(node.value) > 0)
                Search(node.right, value);
            else if (value.CompareTo(node.value) < 0)
                Search(node.left, value);
            return null;*/
            //TreeNode<T> node = _root;
            while (node != null)
            {
                if (value.CompareTo(node.Value) == 0)
                {
                    return node;
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                    node = node.Left;
            }
            return null; //Not Found
        }

        public virtual bool Contains(T value)
        {
            if (FindElement(_root, value) != null)
                return true;
            return false;
        }
        #endregion

        #region Enumerator
        public virtual IEnumerator<T> GetEnumerator()
        {
            _collection.Clear();
            switch (TraversalOrder)
            {
                case TraversalMode.InorderTraversal:
                    InorderTraversalCollectionTest(_root);
                    break;
                case TraversalMode.PostorderTraversal:
                    PostorderTraversalCollection(_root);
                    break;
                case TraversalMode.PreorderTraversal:
                    PreorderTraversalCollection(_root);
                    break;
                default: InorderTraversalCollection(_root);
                    break;
            }
            foreach (var item in _collection)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
