using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_Ed1_ABB.Helpers;
using Lab2_Ed1_ABB.Models;


namespace Lab2_Ed1_ABB.Controllers
{
    public class FileController : Controller
    {
        string route = "";

        public ActionResult CreateInventory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInventory(HttpPostedFileBase file)
        {
            FileModel UploadFile = new FileModel();
            ReadFile readFile = new ReadFile();
            if (file != null)
            {
                route = Server.MapPath("~/Inventories/");
                route += file.FileName;
                Storage.Instance.route = route;
                UploadFile.UploadFile(route, file);
                ViewBag.Error = UploadFile.error;
                ViewBag.Confirmation = UploadFile.Confirmation;

                readFile.ReadFiles();
            }
            return View();
        }
        [HttpGet]
        public ActionResult goCreateOrder()
        {
            if (Storage.Instance.route != null)
            {
                return RedirectToAction("CreateUser", "Order");
            }
            else
            {
                ViewBag.dontFile = "No se ha cargado ningun arcivo";
                return View("CreateInventory");
            }
           
        }

    }
}
