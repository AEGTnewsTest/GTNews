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
    public class QuestionsController : Controller
    {
        private GTnewsEntities db = new GTnewsEntities();

        // GET: Questions
        public ActionResult Index()
        {
            var question = db.Question.Include(q => q.Menu2).ToList();
            

            return View(question.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext");
            return View();
        }

        // POST: Questions/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "qa_id,menu2_id,qa_CNtitle,qa_TWtitle,qa_sort,qa_status,qa_CNtext,qa_TWtext,qa_createdate,qa_editdate")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext", question.menu2_id);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext", question.menu2_id);
            return View(question);
        }

        // POST: Questions/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "qa_id,menu2_id,qa_CNtitle,qa_TWtitle,qa_sort,qa_status,qa_CNtext,qa_TWtext,qa_createdate,qa_editdate")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.menu2_id = new SelectList(db.Menu2, "menu2_id", "menu2_CNtext", question.menu2_id);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Question.Find(id);
            db.Question.Remove(question);
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
        [HttpPost]
        public ActionResult SearchString(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                using (Models.GTnewsEntities db = new Models.GTnewsEntities())
                {
                    var result = db.Question.Include(q => q.Menu2).ToList();
                    result = (from s in db.Question where s.qa_TWtitle.Contains(search) select s).ToList();
                    
                    return View("Index", result);
                }
            }
            else
            {
                return Redirect("Index");
            }
        }

    }
}
