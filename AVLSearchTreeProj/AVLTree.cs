using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLSearchTreeProj
{


    public class AVLTree
    {
        private AVLTreeNode Root;

        public void Insert(int key)
        {
            Root = Insert(Root, key);
        }

        private AVLTreeNode Insert(AVLTreeNode node, int key)
        {
            if (node == null)
                return new AVLTreeNode(key);

            if (key < node.Key)
                node.Left = Insert(node.Left, key);
            else if (key > node.Key)
                node.Right = Insert(node.Right, key);
            else
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            if (balance > 1 && key < node.Left.Key)
                return RotateRight(node);
            if (balance < -1 && key > node.Right.Key)
                return RotateLeft(node);
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void Delete(int key)
        {
            Root = Delete(Root, key);
        }

        private AVLTreeNode Delete(AVLTreeNode node, int key)
        {
            if (node == null)
                return node;

            if (key < node.Key)
                node.Left = Delete(node.Left, key);
            else if (key > node.Key)
                node.Right = Delete(node.Right, key);
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    AVLTreeNode temp = node.Left ?? node.Right;
                    node = temp;
                }
                else
                {
                    AVLTreeNode temp = GetMinValueNode(node.Right);

                    node.Key = temp.Key;

                    node.Right = Delete(node.Right, temp.Key);
                }
            }

            if (node == null)
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RotateRight(node);
            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            if (balance < -1 && GetBalance(node.Right) <= 0)
                return RotateLeft(node);
            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public bool Search(int key)
        {
            return Search(Root, key) != null;
        }

        private AVLTreeNode Search(AVLTreeNode node, int key)
        {
            if (node == null || node.Key == key)
                return node;

            if (key < node.Key)
                return Search(node.Left, key);

            return Search(node.Right, key);
        }

        private AVLTreeNode GetMinValueNode(AVLTreeNode node)
        {
            AVLTreeNode current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }

        private int GetHeight(AVLTreeNode node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(AVLTreeNode node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLTreeNode RotateRight(AVLTreeNode y)
        {
            AVLTreeNode x = y.Left;
            AVLTreeNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLTreeNode RotateLeft(AVLTreeNode x)
        {
            AVLTreeNode y = x.Right;
            AVLTreeNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
            Console.WriteLine();
        }

        private void InOrderTraversal(AVLTreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Key + " ");
                InOrderTraversal(node.Right);
            }
        }
    }

}