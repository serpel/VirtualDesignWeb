using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualDesign.Models;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace VirtualDesign.Controllers
{
    public class ModelController : Controller
    {
        private VirtualContext db = new VirtualContext();

        // GET: /Model/
        public async Task<ActionResult> Index()
        {
            var list = await db.Models.ToListAsync();
            ViewBag.column = 3;
            return View(list);
        }

        //one year facebook cache 
        [OutputCache(Duration = 60 * 60 * 24 * 365, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult FacebookChannel()
        {
            return View();
        }

        // GET: /Model/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(model);
        }

        // GET: /Model/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: /Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ModelId,Name,UserName,Description,CategoryId,Tags,PictureFile,ModelFile")] Model model, HttpPostedFileBase file, HttpPostedFileBase modelFile)
        {
            if (ModelState.IsValid)
            {
                model.Likes = 0;
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                model.PictureFile = await UploadService.UploadFileAsync("images", file);
                model.ModelFile = await UploadService.UploadFileAsync("models", modelFile);
                db.Models.Add(model);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");

            return View(model);
        }
     
        // GET: /Model/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }      
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");

            return View(model);
        }

        // POST: /Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ModelId,Username,Name,Description,CategoryId,Tags,PictureFile,ModelFile,IsActive,CreatedDate")] Model model, HttpPostedFileBase file, HttpPostedFileBase modelFile)
        {
            if (ModelState.IsValid)
            {
                model.PictureFile = await UploadService.UploadFileAsync("images", file);
                model.ModelFile = await UploadService.UploadFileAsync("models", modelFile);
                db.Entry(model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            }
            return View(model);
        }

        // GET: /Model/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: /Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Model model = await db.Models.FindAsync(id);
            db.Models.Remove(model);
            await db.SaveChangesAsync();
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
