using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KHCharacterEdit.DAL;
using KHCharacterEdit.Models;

namespace KHCharacterEdit.Controllers
{
    public class AbilityController : Controller
    {
        private KHContext db = new KHContext();

        // GET: Ability
        public ActionResult Index()
        {
            return View(db.Abilities.ToList());
        }

        // GET: Ability/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // GET: Ability/Details/5
        public ActionResult DetailsExternal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // GET: Ability/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ability/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AbilityPoints,Description")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                db.Abilities.Add(ability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ability);
        }

        // GET: Ability/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // POST: Ability/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AbilityPoints,Description")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ability);
        }

        // GET: Ability/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = db.Abilities.Find(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // POST: Ability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ability ability = db.Abilities.Find(id);
            db.Abilities.Remove(ability);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException) //Impede a aplicação de travar ao tentar apagar um registro já vinculado a outro e mostra um aviso na tela
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You cannnot delete an ability already equipped to a character, accessory or weapon!');</script>");
            }
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
