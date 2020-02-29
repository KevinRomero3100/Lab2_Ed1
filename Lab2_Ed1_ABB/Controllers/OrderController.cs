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
        public ActionResult CreateUser()
        {
            return View();
        }
       public ActionResult Order()
       {
            return View();
       }
        [HttpPost]
        public ActionResult CreateUser(FormCollection collection)
        {
            try
            {
                var user = new UserDS
                {
                    UserName = collection["UserName"],
                    Direction = collection["Direction"],
                    Nit = int.Parse(collection["Nit"])
                };

                if (user.UserName == "" && user.Direction == "")
                {
                    ViewBag.Error = "No ingreso su Direccón y Nombre";
                    return View();
                }
                else if (user.UserName == "")
                {
                    ViewBag.Error = "No ingreso su nombre";
                    return View();
                }
                else if (user.Direction == "")
                {
                    ViewBag.Error = "No ingreso su Direccón";
                    return View();
                }
                else
                {
                    return RedirectToAction("Order", "Order");
                }

            }
            catch (Exception)
            {
                
                ViewBag.Error = "No ingreso su nit";
                return View();
            }

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
            if (found != null)
            {
                return View(readFile.SearcInFile(found.Value.lineNumber));
            }
            else
            {
                ViewBag.mensage = "Medicamento no encontrado";
                return View();
            }
            
        }


    }
}
