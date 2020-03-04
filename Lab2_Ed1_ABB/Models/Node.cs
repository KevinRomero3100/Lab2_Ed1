using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2_Ed1_ABB.Models;

namespace Lab2_Ed1_ABB.Models
{
    public class Node
    {
        //private Node Parent { get; set; }
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Medication medications = new Medication();
        public Node()
        {

        }
        public Node(Medication medications)
        {
            this.medications = medications;
        }
        public Node(Medication medications, Node left, Node right, Node parent)
        {
            this.medications = medications;
            this.Left = left;
            this.Right = right;
            this.Parent = parent;
        }
        public bool findleft()
        {
            if (Left != null)
                return true;
            return false;
        }
        public bool findright()
        {
            if (Right != null)
                return true;
            return false;
        }
        public bool Root()
        {
            if (Parent != null)
                return false;
            return true;
        }
        public bool storedMedicaments()
        {
            if (medications != null)
                return false;
            return true;
        }

    }
}