using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustumGenerics.Structures;
using Lab2_Ed1_ABB.Models;

namespace Lab2_Ed1_ABB.Controllers
{

        
    public class HomeController : Controller
    {
        public BinaryTree<Indice> binary = new BinaryTree<Indice>();
        public ActionResult Index()
        {
            var value = new Indice { lineNumber = 6, nameDrug = "k" };
            var value2 = new Indice { lineNumber = 6, nameDrug = "m" };
            var value3 = new Indice { lineNumber = 6, nameDrug = "a" };
            var value4 = new Indice { lineNumber = 6, nameDrug = "g" };
            var value5 = new Indice { lineNumber = 6, nameDrug = "y" };
            var value6 = new Indice { lineNumber = 6, nameDrug = "z" };
            var value7 = new Indice { lineNumber = 6, nameDrug = "e" };
            binary.Insert(value, Indice.comparisonbyName);
            binary.Insert(value2, Indice.comparisonbyName);
            binary.Insert(value3, Indice.comparisonbyName);
            binary.Insert(value4, Indice.comparisonbyName);
            binary.Insert(value5, Indice.comparisonbyName);
            binary.Insert(value6, Indice.comparisonbyName);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}