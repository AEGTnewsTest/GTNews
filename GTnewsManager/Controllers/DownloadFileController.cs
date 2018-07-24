using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTnewsManager.Controllers
{
    public class DownloadFileController : Controller
    {
        // GET: DownloadFile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DownloadFile(string directoryName,string name)
        {
            string path = Server.MapPath(@"~\File\" + name);
            return File(path, "application/octet-stream");
        }
    }
}