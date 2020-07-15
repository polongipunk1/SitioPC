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
using Microsoft.AspNet.Identity;

namespace SitioPC.Controllers
{
    
    public class ventaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ventas
        public ActionResult Index()
        {            
            return View(db.venta.ToList().OrderBy(x => x.fecha));
        }

        //MisCompras
        [Authorize(Roles = "Cliente"), RequireHttps]
        public ActionResult MisCompras()
        {
            var usrId = User.Identity.GetUserId();
            var cm = db.venta.Where(x => x.ApplicationUserId == usrId);
            return View(cm.ToList());
        }
 
        // GET: ventas/Details/5
        public ActionResult Details(int? id)
        {
            return View(db.venta.Find(id));
        }        
        }
    }
