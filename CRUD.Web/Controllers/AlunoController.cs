using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD;
using CRUD.Model;

namespace CRUD.Web.Controllers
{
    public class AlunoController : Controller
    {
        private CRUDContext db = new CRUDContext();

        // GET: Aluno
        public ActionResult Index()
        {
            return View(db.AlunoModels.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.AlunoModels.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMatric,Nome,SobreNome")] AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.AlunoModels.Add(alunoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alunoModel);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.AlunoModels.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMatric,Nome,SobreNome")] AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alunoModel);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.AlunoModels.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoModel alunoModel = db.AlunoModels.Find(id);
            db.AlunoModels.Remove(alunoModel);
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
