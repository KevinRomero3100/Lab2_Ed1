using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2_Ed1_ABB.Helpers;

namespace Lab2_Ed1_ABB.Models
{
    public class Indice
    {
        public int lineNumber { get; set; }
        public string nameDrug { get; set; }

        public static Comparison<Indice> comparisonbyName = delegate (Indice indice1, Indice indice2)
        {
            return indice1.nameDrug.CompareTo(indice2.nameDrug);
        };
        public void saveIndice()
        {
            Storage.Instance.binaryTree.Insert(this, comparisonbyName);
        }

    } 
}