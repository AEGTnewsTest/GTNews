using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTnewsManager.Models;
namespace GTnewsManager.Controllers
{
    
    public class UploadController : Controller
    {
         
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/File"), fileName);
                file.SaveAs(path);
                TempData["ResultMessage"] = string.Format("檔案[{0}]上傳成功", fileName);
            }
            return RedirectToAction("Upload");
        }


    }
}