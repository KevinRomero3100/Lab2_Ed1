using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Ed1_ABB.Models
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        public void creation()
        {
            Root = null;
        }

        public void deleteTree(string serie)
        {
            deleteTree(Root, serie);
        }
        private void deleteTree(Node leaves, string serie)
        {
            if (leaves != null)
            {
                int tem = leaves.medications.NameDrug.CompareTo(serie);
                Node auxiliar = null;
                Node auxiliar2 = null;
                Node other = null;
                //other = leaves;
                if (tem > 0)
                {
                    deleteTree(leaves.Left, serie);
                }
                else
                {
                    if (tem < 0)
                    {
                        deleteTree(leaves.Right, serie);
                    }
                    else
                    {
                        other = leaves;
                        if (other != null)
                        {
                            if (other.Right == null && other.Left == null)
                            {
                                other = null;
                            }
                            else
                            {
                                if (other.Right == null)
                                {
                                    leaves = other.Left;
                                }
                                else
                                    //  {
                                    if (other.Left == null)
                                {
                                    leaves = other.Right;
                                }
                                // }
                                else
                                {
                                    auxiliar = other.Left;
                                    auxiliar2 = auxiliar;
                                    while (auxiliar.Right != null)
                                    {
                                        auxiliar2 = auxiliar;
                                        auxiliar = auxiliar.Right;
                                    }
                                    other.medications = auxiliar.medications;
                                    other = auxiliar;
                                    auxiliar2.Right = auxiliar.Left;
                                    auxiliar = null;
                                }
                            }
                        }
                    }
                }
            }
        }
        /*private Node fill(string serie, Node leaves, int lot)
        {
            if (leaves != null)
            {
                int tem = leaves.medications.NameDrug.CompareTo(serie);
                if (serie == leaves.medications.NameDrug)
                {
                    leaves.medications.Stock = leaves.medications.Stock - lot;
                    return leaves;
                }
            }
        }*/
        public void Insertion(Node insertion)
        {
            if (Root == null)
            {
                Root = insertion;
            }
            else
            {
                Insertion(insertion, Root);
            }
        }
        private void Insertion(Node insertion, Node leaves)
        {
            int number = leaves.medications.NameDrug.CompareTo(insertion.medications.NameDrug);
            if (number > 0)
            {
                if (leaves.Left != null)
                {
                    Insertion(insertion, leaves.Left);
                }
                else
                {
                    leaves.Left = insertion;
                }
            }
            else if (number <= 0)
            {
                if (leaves.Right != null)
                {
                    Insertion(insertion, leaves.Right);
                }
                else
                {
                    leaves.Right = insertion;
                }
            }
        }
    }
}