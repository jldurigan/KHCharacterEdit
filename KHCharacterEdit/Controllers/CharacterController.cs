using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KHCharacterEdit.DAL;
using KHCharacterEdit.Models;

namespace KHCharacterEdit.Controllers
{
    public class CharacterController : Controller
    {
        private KHContext db = new KHContext();

        // GET: Character
        public ActionResult Index()
        {
            var characters = db.Characters.Include(c => c.Weapon);
            return View(characters.ToList());
        }

        // GET: Character/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            ViewBag.WeaponID = new SelectList(db.Weapons, "ID", "Name");
            return View();
        }

        // POST: Character/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ArmorSlots,AccessorySlots,WeaponID,AbilitySlots,WeaponType")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WeaponID = new SelectList(db.Weapons, "ID", "Name", character.WeaponID);
            return View(character);
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.WeaponID = new SelectList(db.Weapons, "ID", "Name", character.WeaponID); //Gera a lista que vai preencher a DropDownList na View
            ViewBag.Armors = new SelectList(db.Armors, "ID", "Name", character.Armors); //Gera a lista que vai preencher a DropDownList na View
            ViewBag.Accessories = new SelectList(db.Accessories, "ID", "Name", character.Accessories); //Gera a lista que vai preencher a DropDownList na View
            ViewBag.Abilities = new SelectList(db.Abilities, "ID", "Name", character.Abilities); //Gera a lista que vai preencher a DropDownList na View
            return View(character);
        }

        // POST: Character/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ArmorSlots,AccessorySlots,WeaponID,AbilitySlots,WeaponType")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WeaponID = new SelectList(db.Weapons, "ID", "Name", character.WeaponID);
            ViewBag.Armors = new SelectList(db.Armors, "ID", "Name", character.Armors);
            ViewBag.Accessories = new SelectList(db.Accessories, "ID", "Name", character.Accessories);
            ViewBag.Abilities = new SelectList(db.Abilities, "ID", "Name", character.Abilities);
            return View(character);
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
