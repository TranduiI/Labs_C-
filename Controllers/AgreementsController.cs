using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabASP.Models;

namespace LabASP.Controllers
{
    public class AgreementsController : Controller
    {
        private ContosoUniversityDataEntities2 db = new ContosoUniversityDataEntities2();

        // GET: Agreements
        public ActionResult Index()
        {
            var agreements = db.Agreements.Include(a => a.User).Include(a => a.Product);
            return View(agreements.ToList());
        }

        // GET: Agreements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = db.Agreements.Find(id);
            if (agreement == null)
            {
                return HttpNotFound();
            }
            return View(agreement);
        }

        // GET: Agreements/Create
        public ActionResult Create()
        {
            ViewBag.ID_пользователя = new SelectList(db.Users, "ID_пользователя", "ФИО");
            ViewBag.Код_товара = new SelectList(db.Products, "Код_товара", "Наименование_");
            return View();
        }

        // POST: Agreements/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Номер_договора,ID_пользователя,Код_товара,ФИО,Дата_рождения,Номер_и_серия_паспорта,Адрес,Номер,Дата_составления")] Agreement agreement)
        {
            if (ModelState.IsValid)
            {
                db.Agreements.Add(agreement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_пользователя = new SelectList(db.Users, "ID_пользователя", "ФИО", agreement.ID_пользователя);
            ViewBag.Код_товара = new SelectList(db.Products, "Код_товара", "Наименование_", agreement.Код_товара);
            return View(agreement);
        }

        // GET: Agreements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = db.Agreements.Find(id);
            if (agreement == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_пользователя = new SelectList(db.Users, "ID_пользователя", "ФИО", agreement.ID_пользователя);
            ViewBag.Код_товара = new SelectList(db.Products, "Код_товара", "Наименование_", agreement.Код_товара);
            return View(agreement);
        }

        // POST: Agreements/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Номер_договора,ID_пользователя,Код_товара,ФИО,Дата_рождения,Номер_и_серия_паспорта,Адрес,Номер,Дата_составления")] Agreement agreement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agreement).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_пользователя = new SelectList(db.Users, "ID_пользователя", "ФИО", agreement.ID_пользователя);
            ViewBag.Код_товара = new SelectList(db.Products, "Код_товара", "Наименование_", agreement.Код_товара);
            return View(agreement);
        }

        // GET: Agreements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = db.Agreements.Find(id);
            if (agreement == null)
            {
                return HttpNotFound();
            }
            return View(agreement);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agreement agreement = db.Agreements.Find(id);
            db.Agreements.Remove(agreement);
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
