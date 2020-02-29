using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustumGenerics.Structures;
using Lab2_Ed1_ABB.Models;

namespace Lab2_Ed1_ABB.Helpers
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }
        public BinaryTree<Indice> binaryTree = new BinaryTree<Indice>();
        public List<Medication> showMedication = new List<Medication>();
        public UserDS user = new UserDS();
        public string route = null;
    }
}