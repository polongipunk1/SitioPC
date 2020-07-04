using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using SitioPC.Models;
using System.Web.Helpers;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SitioPC.Controllers
{
    [Authorize, RequireHttps]
    public class productosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: productos        
        public ActionResult Index()
        {          
            return View(db.productos.ToList());
        }

        // GET: Lista
        [AllowAnonymous]
        public ActionResult Lista()
        {
            return View(db.productos.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,procesador,graficos,ram,pantalla,almacenamiento,bateria,so,audio,puertos,conectividad,precio,existencias,img")] productos productos)
        {
            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase.ContentLength == 0)
            {
                ModelState.AddModelError("Imagen","Seleccione una imagen para el producto");
            }
            else
            {
                if (FileBase.FileName.EndsWith(".png") || FileBase.FileName.EndsWith(".PNG"))
                {
                    WebImage image = new WebImage(FileBase.InputStream);
                    productos.img = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Solo se admiten imagenes con formato .png");
                }
                
            }            

            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

        // GET: productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,procesador,graficos,ram,pantalla,almacenamiento,bateria,so,audio,puertos,conectividad,precio,existencias,img")] productos productos)
        {
            //byte[] imagenActual = null;
            productos _productos = new productos();

            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.ContentLength == 0)
            {
                _productos = db.productos.Find(productos.Id);
                productos.img = _productos.img;
            }else
            {
                if (FileBase.FileName.EndsWith(".png") || FileBase.FileName.EndsWith(".PNG"))
                {
                    WebImage image = new WebImage(FileBase.InputStream);
                    productos.img = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Solo se admiten imagenes con formato .png");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(_productos).State = EntityState.Detached;
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        // GET: productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
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

        [AllowAnonymous]
        public ActionResult getImage(int? id)
        {
            productos productoK = db.productos.Find(id);
            byte[] byteImage = productoK.img;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;

            return File(memoryStream,"image/png");
        }
    }
}
