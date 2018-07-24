using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTnewsManager.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            //ViewBag.ResultMessage = TempData["ResultMessage"];
            //string xresult = "";
            List<FileInfo> result = new List<FileInfo>();
            //int i = 1;
            string rootpath = Request.PhysicalApplicationPath; //抓取專案所在實際目錄路徑
            DirectoryInfo docspath = new DirectoryInfo(rootpath + "File"); // 搭配專案相對應上傳的路徑
            FileInfo[] filelist = docspath.GetFiles();  //擷取目錄下所有檔案內容，並存到 FileInfo array
            //xresult = "<TABLE width=90% style='border:1px dashed #2f6fab; background-color: #eaf2d3;'>";
            //xresult += "<TR style='background-color:#5B9BD5;'><TD width='15%'>項次</TD><TD width='70%'>檔案名稱</TD><TD width='15%'>檔案大小</TD></TR>";
            //foreach (FileInfo fl in filelist)
            //{
                /*if (i % 5 == 0)  // 每五行以不同底色呈現表格樣式
                {
                    xresult += "<TR style='background-color:#ABC7E7;'><TD>" + i + "</TD><TD><a href='http://your_domain/Uploads/ " + fl.Name + "'>" + fl.Name + "</a></TD><TD>" + fl.Length + "</TD></TR>";
                }
                else
                {
                    xresult += "<TR><TD>" + i + "</TD><TD><a href='http:// your_domain /Uploads/" + fl.Name + "'>" + fl.Name + "</TD><TD>" + fl.Length + "</a></TD></TR>";
                }
                FileInfo fl
                i++;  //  顯示行號用之變數*/

            //}
            
            result = (from s in filelist select s).ToList();

            //xresult += "</TABLE>";
            return View(result);
        }
        public ActionResult DownloadFile(string directoryName, string name)
        {
            
            TempData["ResultMessage"] = "下載成功";
            string path = Server.MapPath(@"~\File\" + name);
            Stream istream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            
            return File(istream,"application/zip",name);
            
        }


        public ActionResult Upload()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if(file != null) { 
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/File"), fileName);
                    file.SaveAs(path);
                
                    TempData["ResultMessage"] = string.Format("檔案[{0}]上傳成功", fileName);
                }
            }
            return RedirectToAction("Search");
        }
        [HttpPost]
        public ActionResult Remove(string directoryName, string name)
        {
            List <FileInfo> result = new List<FileInfo>();
            //string rootpath = Request.PhysicalApplicationPath; //抓取專案所在實際目錄路徑
           // DirectoryInfo docspath = new DirectoryInfo(rootpath + "File"); // 搭配專案相對應上傳的路徑
            //FileInfo[] filelist = docspath.GetFiles();  //擷取目錄下所有檔案內容，並存到 FileInfo array
                                                        //result = (from s in filelist select s).ToList();
            //result = (from s in dbb select s).ToList();
            //var file = (from s in filelist where s.Name == name select s).FirstOrDefault();
            System.IO.File.Delete(@"" + directoryName + @"\" + name + @"");
            
            //dbb.RemoveAll(it => it.Name == name);
            //TempData["ResultMessage"] = @"" + directoryName + @"\" + name + @"";
            //result.Remove(file);
            return RedirectToAction("Search");
        }

      

    }
}