using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GTnewsManager.Models;

namespace GTnewsManager.Controllers
{
    public class Menu2Controller : Controller
    {
        private GTnewsEntities db = new GTnewsEntities();

        // GET: Menu2
        public ActionResult Index()
        {
            var menu2 = db.Menu2.Include(m => m.Menu);
            return View(menu2.ToList());
        }

        // GET: Menu2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu2 menu2 = db.Menu2.Find(id);
            if (menu2 == null)
            {
                return HttpNotFound();
            }
            return View(menu2);
        }

        // GET: Menu2/Create
        public ActionResult Create()
        {
            ViewBag.menu_id = new SelectList(db.Menu, "menu_id", "menu_TWtext");
            return View();
        }

        // POST: Menu2/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "menu2_id,menu_id,menu2_CNtext,menu2_TWtext,menu2_url,menu2_sort,menu2_status,menu2_type")] Menu2 menu2)
        {
            if (ModelState.IsValid)
            {
                db.Menu2.Add(menu2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.menu_id = new SelectList(db.Menu, "menu_id", "menu_TWtext", menu2.menu_id);
            return View(menu2);
        }

        // GET: Menu2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu2 menu2 = db.Menu2.Find(id);
            if (menu2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.menu_id = new SelectList(db.Menu, "menu_id", "menu_TWtext", menu2.menu_id);
            return View(menu2);
        }

        // POST: Menu2/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "menu2_id,menu_id,menu2_CNtext,menu2_TWtext,menu2_url,menu2_sort,menu2_status,menu2_type")] Menu2 menu2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.menu_id = new SelectList(db.Menu, "menu_id", "menu_TWtext", menu2.menu_id);
            return View(menu2);
        }

        // GET: Menu2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu2 menu2 = db.Menu2.Find(id);
            if (menu2 == null)
            {
                return HttpNotFound();
            }
            return View(menu2);
        }

        // POST: Menu2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu2 menu2 = db.Menu2.Find(id);
            db.Menu2.Remove(menu2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
