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
    public class EventsController : Controller
    {
        private GTnewsEntities db = new GTnewsEntities();

        // GET: Events
        public ActionResult Index()
        {
            var @event = db.Event.Include(m => m.Menu2);
            return View(@event.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext");
            return View();
        }

        // POST: Events/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "event_id,menu2_id,event_pictureUrl,event_CNtitle,event_TWtitle,event_date,event_CNtext,event_TWtext,event_downloadUrl,event_status,event_sort,event_createdate,event_editdate")] Event @event)
        {
            
            if (ModelState.IsValid)
            {
                db.Event.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext", @event.menu2_id);
            @event.event_TWtitle = HttpUtility.HtmlDecode(@event.event_TWtitle);
            return View(@event);
        }

        // GET: Events/Edit/5
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            @event.event_TWtitle = HttpUtility.HtmlDecode(@event.event_TWtitle);
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext", @event.menu2_id);
            return View(@event);
        }

        // POST: Events/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "event_id,menu2_id,event_pictureUrl,event_CNtitle,event_TWtitle,event_date,event_CNtext,event_TWtext,event_downloadUrl,event_status,event_sort,event_createdate,event_editdate")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext", @event.menu2_id);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
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
