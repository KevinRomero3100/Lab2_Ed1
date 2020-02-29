using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_Ed1_ABB.Helpers;
using Lab2_Ed1_ABB.Models;

namespace Lab2_Ed1_ABB.Controllers
{
    public class OrderController : Controller
    {
       public ActionResult Order()
       {
            return View();
       }

       [HttpPost]
       public ActionResult Order(FormCollection collection)
        {
            var readFile = new ReadFile();
            var nameDrug = collection["search"];
            var indicesearched = new Indice
            {
                nameDrug = collection["search"]
            };
            var found = Storage.Instance.binaryTree.search(indicesearched, Indice.comparisonbyName);
            return View(readFile.SearcInFile(found.Value.lineNumber));
        }


    }
}
