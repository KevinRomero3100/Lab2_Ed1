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
                UploadFile.UploadFile(route, file);
                ViewBag.Error = UploadFile.error;
                ViewBag.Confirmation = UploadFile.Confirmation;

                readFile.ReadFiles(route);
            }
            return View();
        }


        public ActionResult goCreateOrder()
        {
            return RedirectToAction("");
        }

    }
}
