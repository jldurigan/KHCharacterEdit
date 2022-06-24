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
    public class ArmorController : Controller
    {
        private KHContext db = new KHContext();

        // GET: Armor
        public ActionResult Index()
        {
            return View(db.Armors.ToList());
        }

        // GET: Armor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // GET: Armor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Strength,Defense,FireResistance,IceResistance,ThunderResistance,DarkResistance")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                db.Armors.Add(armor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(armor);
        }

        // GET: Armor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // POST: Armor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Strength,Defense,FireResistance,IceResistance,ThunderResistance,DarkResistance")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(armor);
        }

        // GET: Armor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armor armor = db.Armors.Find(id);
            if (armor == null)
            {
                return HttpNotFound();
            }
            return View(armor);
        }

        // POST: Armor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armor armor = db.Armors.Find(id);
            db.Armors.Remove(armor);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException) //Impede a aplicação de travar ao tentar apagar um registro já vinculado a outro e mostra um aviso na tela
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You can't delete an armor already equipped to a character!');</script>");
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
