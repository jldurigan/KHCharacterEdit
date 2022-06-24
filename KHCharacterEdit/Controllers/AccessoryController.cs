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
    public class AccessoryController : Controller
    {
        private KHContext db = new KHContext();

        // GET: Accessory
        public ActionResult Index()
        {
            var accessories = db.Accessories.Include(a => a.Ability);
            return View(accessories.ToList());
        }

        // GET: Accessory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessory/Create
        public ActionResult Create()
        {
            ViewBag.AbilityID = new SelectList(db.Abilities, "ID", "Name");
            return View();
        }

        // POST: Accessory/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AbilityPoints,Strength,Magic,AbilityID")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AbilityID = new SelectList(db.Abilities, "ID", "Name", accessory.AbilityID);
            return View(accessory);
        }

        // GET: Accessory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbilityID = new SelectList(db.Abilities, "ID", "Name", accessory.AbilityID);
            return View(accessory);
        }

        // POST: Accessory/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AbilityPoints,Strength,Magic,AbilityID")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AbilityID = new SelectList(db.Abilities, "ID", "Name", accessory.AbilityID);
            return View(accessory);
        }

        // GET: Accessory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            db.Accessories.Remove(accessory);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException) //Impede a aplicação de travar ao tentar apagar um registro já vinculado a outro e mostra um aviso na tela
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You can't delete an accessory already equipped to a character!');</script>");
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
