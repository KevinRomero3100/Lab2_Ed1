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
        static List<Node> reFill = new List<Node>();

        public ActionResult CreateUser()
        {
            return View();
        }
       public ActionResult Car()
        {
            return View();
        }
       public ActionResult Order()
       {
            return View(Storage.Instance.showMedication);
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
                    Storage.Instance.user = user;
                    return RedirectToAction("Order", "Order");
                }

            }
            catch (Exception)
            {
                
                ViewBag.Error = "No ingreso su nit";
                return View();
            }

        }

        public ActionResult goToCar()
        {
            double total = 0;
            foreach (var item in Storage.Instance.showCar)
            {
                total += item.Stock * Convert.ToDouble(item.Price);
            }
            @ViewBag.Total = total;
            return View("Car", Storage.Instance.showCar);
        }

        [HttpPost]
       public ActionResult searchMedicament(FormCollection collection)
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
                return View("Order",ReadFile.SearcInFile(found.Value.lineNumber));
            }
            else
            {
                ViewBag.mensage = "Medicamento no encontrado";
                return View("Order");
            }
            
        }
        [HttpPost]
        public ActionResult AddOrder(FormCollection collection)
        {
            try
            {
                Medication newmedication = new Medication();
                List<Medication> showMedication = Storage.Instance.showMedication;
                var solicitud = int.Parse(collection["cantidad"]);
                foreach (var item in showMedication)
                {
                    newmedication = item;
                }
                if (newmedication.Stock >= solicitud)
                {
                    int oldStock = newmedication.Stock;
                    ViewBag.Confirmation = "Solicitud aceptada y descargada con exito del inventario";
                    ViewBag.Error = null;
                    ReadFile.editStock(newmedication.Id, newmedication.Stock - solicitud, Server.MapPath("~/Inventories/"));
                    newmedication.Stock = solicitud;
                    Storage.Instance.showCar.Add(newmedication);
                    Storage.Instance.showMedication = ReadFile.SearcInFile(newmedication.Id);

                    return View("Order");
                }
                else
                {
                    ViewBag.Error = "No hay suficientes ecistencias del producto";
                    return View("Order", Storage.Instance.showMedication);
                }

               
            }
            catch (Exception)
            {
                ViewBag.Error = "Formato de solicitud invalido intentelo de nuevo";
                return View("Order", Storage.Instance.showMedication);
            }
        }
        public ActionResult ReFill()
        {
            Random number = new Random();
            foreach (var item in reFill)
            {
                Node insert = new Node();
                insert = item;
                insert.Left = null;
                insert.Right = null;
                insert.medications.Stock = number.Next(0, 15);
                Tree.Insertion(insert);
            }
            reFill.Clear();
            return View();
        }
    }
}
