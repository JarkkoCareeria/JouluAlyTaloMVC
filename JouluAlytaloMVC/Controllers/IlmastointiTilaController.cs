using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JouluAlytaloMVC.Models;

namespace JouluAlytaloMVC.Controllers
{
    public class IlmastointiTilaController : Controller
    {
        private JouluAlyTaloDBEntities db = new JouluAlyTaloDBEntities();

        // GET: IlmastointiTila
        public ActionResult Index()
        {
            return View(db.Ilmastointi.ToList());
        }

        // GET: IlmastointiTila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilmastointi ilmastointi = db.Ilmastointi.Find(id);
            if (ilmastointi == null)
            {
                return HttpNotFound();
            }
            return View(ilmastointi);
        }

        // GET: IlmastointiTila/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IlmastointiTila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IlmastointiID,IlmastoinninTila,IlmastointiTaso,Huone")] Ilmastointi ilmastointi)
        {
            if (ModelState.IsValid)
            {
                db.Ilmastointi.Add(ilmastointi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilmastointi);
        }

        // GET: IlmastointiTila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilmastointi ilmastointi = db.Ilmastointi.Find(id);
            if (ilmastointi == null)
            {
                return HttpNotFound();
            }
            return View(ilmastointi);
        }

        // POST: IlmastointiTila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IlmastointiID,IlmastoinninTila,IlmastointiTaso,Huone")] Ilmastointi ilmastointi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilmastointi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilmastointi);
        }

        // GET: IlmastointiTila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilmastointi ilmastointi = db.Ilmastointi.Find(id);
            if (ilmastointi == null)
            {
                return HttpNotFound();
            }
            return View(ilmastointi);
        }

        // POST: IlmastointiTila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilmastointi ilmastointi = db.Ilmastointi.Find(id);
            db.Ilmastointi.Remove(ilmastointi);
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
