﻿/* BinaryTreeNode.cs
 * Author: Rod Howell 
 * Edited: Joe Webster | CIS 300: M W F 11:30-1:20
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.ImmutableBinaryTrees
{
    /// <summary>
    /// An immutable generic binary tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public class BinaryTreeNode<T> : ITree
    {
        /// <summary>
        /// Private int "_treeHeight" stores the height of the binary node tree
        /// </summary>
        private int _treeHeight;

        /// <summary>
        /// Public method "Height" returns the height of the binary node tree
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int Height(BinaryTreeNode<T> t)
        {
            //case where tree is empty
            if (t == null)
            {
                return -1;
            }
            else
            {
                //return what is stored in the above field of the given tree...
                return t._treeHeight;
            }
        }

        /// <summary>
        /// The data stored in this node.
        /// </summary>
        private T _data;

        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// This nodes left child.
        /// </summary>
        private BinaryTreeNode<T> _leftChild;

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public BinaryTreeNode<T> LeftChild
        {
            get
            {
                return _leftChild;
            }
        }

        /// <summary>
        /// This node's right child.
        /// </summary>
        private BinaryTreeNode<T> _rightChild;

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public BinaryTreeNode<T> RightChild
        {
            get
            {
                return _rightChild;
            }
        }

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        private BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            _data = data;
            _leftChild = left;
            _rightChild = right;

            //call Height, pass in binarytreenode<T>
            _treeHeight = Math.Max(Height(left), Height(right)) + 1;
        }

        #region Code for rotating trees

        /// <summary>
        /// Builds the result of performing a single rotate right on the binary tree
        /// described by the given root, left child, and right child.
        /// </summary>
        /// <param name="root">The root of the original tree.</param>
        /// <param name="left">The left child of the root of the original tree.</param>
        /// <param name="right">The right child of the root of the original tree.</param>
        /// <returns>The result of performing a single rotate right on the tree described
        /// by the parameters.</returns>
        private static BinaryTreeNode<T> SingleRotateRight(T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            BinaryTreeNode<T> newRight = new BinaryTreeNode<T>(root, left.RightChild, right);
            return new BinaryTreeNode<T>(left.Data, left.LeftChild, newRight);
        }

        /// <summary>
        /// Builds a new binary tree with the original trees nodes rotated left
        /// </summary>
        /// <param name="root">The root of the original tree.</param>
        /// <param name="left">The left child of the root of the original tree.</param>
        /// <param name="right">The right child of the root of the original tree.</param>
        /// <returns>The result of performing a single rotate right on the tree described
        /// by the parameters.</returns>
        private static BinaryTreeNode<T> SingleRotateLeft(T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            BinaryTreeNode<T> newLeft = new BinaryTreeNode<T>(root, left, right.LeftChild);
            return new BinaryTreeNode<T>(right.Data, newLeft, right.RightChild);
        }

        /// <summary>
        /// Builds a new binary tree with the original trees nodes rotated left then right
        /// </summary>
        /// <param name="root">The root of the original tree.</param>
        /// <param name="left">The left child of the root of the original tree.</param>
        /// <param name="right">The right child of the root of the original tree.</param>
        /// <returns>The result of performing a single rotate right on the tree described
        /// by the parameters.</returns>
        private static BinaryTreeNode<T> DoubleRotateRight(T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            BinaryTreeNode<T> newLeft = new BinaryTreeNode<T>(left.Data, left.LeftChild, left.RightChild.LeftChild);
            BinaryTreeNode<T> newRight = new BinaryTreeNode<T>(root, left.RightChild.RightChild, right);
            return new BinaryTreeNode<T>(left.RightChild.Data, newLeft, newRight);
        }

        /// <summary>
        /// Builds a new binary tree with the original trees nodes rotated right then left
        /// </summary>
        /// <param name="root">The root of the original tree.</param>
        /// <param name="left">The left child of the root of the original tree.</param>
        /// <param name="right">The right child of the root of the original tree.</param>
        /// <returns>The result of performing a single rotate right on the tree described
        /// by the parameters.</returns>
        private static BinaryTreeNode<T> DoubleRotateLeft(T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            BinaryTreeNode<T> newRight = new BinaryTreeNode<T>(right.Data, right.LeftChild.RightChild, right.RightChild);
            BinaryTreeNode<T> newLeft = new BinaryTreeNode<T>(root, left, right.LeftChild.LeftChild);
            return new BinaryTreeNode<T>(right.LeftChild.Data, newLeft, newRight);
        }

        /// <summary>
        /// Constructs an AVL Tree from the given data element and trees. The heights of the 
        /// trees must differ by at most two. The tree built will have the same inorder traversal order 
        /// as if the data were at the root, left were the left child, and right were the right
        /// child.
        /// </summary>
        /// <param name="data">A data item to be stored in the tree.</param>
        /// <param name="left">An AVL Tree containing elements less than data.</param>
        /// <param name="right">An AVL Tree containing elements greater than data.</param>
        /// <returns>The AVL Tree constructed.</returns>
        public static BinaryTreeNode<T> GetAvlTree(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            int diff = Height(left) - Height(right);
            if (Math.Abs(diff) > 2)
            {
                throw new ArgumentException();
            }
            else if (diff == 2)
            {
                if (Height(left.LeftChild) > Height(right))
                {
                    return SingleRotateRight(data, left, right);
                }
                else
                {
                    return DoubleRotateRight(data, left, right);
                }
            }
            else if (diff == -2)
            {
                if (Height(right.RightChild) > Height(left))
                {
                    return SingleRotateLeft(data, left, right);
                }
                else
                {
                    return DoubleRotateLeft(data, left, right);
                }
            }
            else
            {
                return new BinaryTreeNode<T>(data, left, right);
            }
        }

        #endregion

        #region Code used for drawing trees

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        ITree[] ITree.Children
        {
            get 
            {
                ITree[] children = new ITree[2];
                children[0] = _leftChild;
                children[1] = _rightChild;
                return children;
            }
        }

        /// <summary>
        /// Gets whether this node is empty. Because empty trees will be represented by
        /// null, it always returns false.
        /// </summary>
        bool ITree.IsEmpty
        {
            get 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Gets the object to be drawn as the contents of this node.
        /// </summary>
        object ITree.Root
        {
            get 
            { 
                return _data; 
            }
        }

        #endregion
    }
}
