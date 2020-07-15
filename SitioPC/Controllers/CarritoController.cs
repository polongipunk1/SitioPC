using SitioPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;

namespace SitioPC.Controllers
{
    [RequireHttps]
    public class CarritoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public JsonResult AgregaCarrito(int? id, int cantidad)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.productos.Find(id), cantidad));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1) 
                { 
                    compras.Add(new CarritoItem(db.productos.Find(id), cantidad));
                }
                else { 
                    compras[IndexExistente].Cantidad += cantidad;
                Session["carrito"] = compras;
                }
            }
            return Json(new { response = true }, JsonRequestBehavior.AllowGet);
        }

        // GET: Carrito
        //Agregar productos a la lista de carrito
        [HttpGet]
        public ActionResult AgregaCarrito()
        {
            /*if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.productos.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente==-1)
                {
                    compras.Add(new CarritoItem(db.productos.Find(id), 1));
                }
                else
                {
                    compras[IndexExistente].Cantidad++;
                    Session["carrito"] = compras;
                }
                
            }*/
            return View();
        }

        //Eliminar un producto de la lista de carrito
        public ActionResult Delete(int? id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));

            return View("AgregaCarrito");
        }

        [Authorize(Roles = "Cliente"), RequireHttps]
        //Logica para finalizar la compra del cliente
        public ActionResult FinalizaCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if (compras != null && compras.Count>0)
            {
                venta nuevaVenta = new venta();                
                nuevaVenta.fecha = DateTime.Now;
                nuevaVenta.ApplicationUserId = User.Identity.GetUserId();
                nuevaVenta.total = compras.Sum(x => x.Producto.precio * x.Cantidad);                

                nuevaVenta.ventadetalle = (from producto in compras
                                           select new ventadetalle
                                           {
                                               productosId = producto.Producto.Id,                                               
                                               nombre = producto.Producto.nombre,
                                               cantidad = producto.Cantidad,
                                               precio = producto.Producto.precio,
                                               subtotal = producto.Cantidad * producto.Producto.precio                                               
                                           }).ToList();

                /*product.existencias = (from producto in compras
                                       select new productos
                                       {
                                           existencias = producto.Producto.existencias - producto.Cantidad
                                       });*/

                db.venta.Add(nuevaVenta);                
                db.SaveChanges();
                Session["carrito"] = new List<CarritoItem>();
            }

            return View();
        }

        //Traer index para saber si ya existe el producto en la lista de carrito
        private int getIndex(int? id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}