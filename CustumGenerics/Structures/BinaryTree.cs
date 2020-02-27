using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustumGenerics.Structures
{
    public class BinaryTree<T>
    {
        public Node<T> Root { get; set; }

        public Node<T> createNode(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.right = null;
            newNode.left = null;
            newNode.Value = value;
            return newNode;
        }

        public void Insert(T value, Comparison<T> comparison)
        {
            Node<T> newNode = createNode(value);
            
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                InsertNode(Root, newNode, comparison);
            }
        }

        public static Node<T> InsertNode(Node<T> actulay, Node<T> newNode,Comparison<T> comparison)
        {

            if (comparison.Invoke(actulay.Value, newNode.Value) == 1)
            {
                if (actulay.right == null)
                {
                    actulay.right = newNode;
                    return actulay;
                }
                else
                {
                    actulay.right = InsertNode(actulay.right, newNode, comparison);
                    return actulay;
                }
            }
            else if (comparison.Invoke(actulay.Value, newNode.Value) == -1)
            {
                if (actulay.left == null)
                {
                    actulay.left = newNode;
                    return actulay;
                }
                else
                {
                    actulay.left = InsertNode(actulay.left, newNode, comparison);
                    return actulay;
                }
            }
            else return null;
        }


            
        
    }
}
