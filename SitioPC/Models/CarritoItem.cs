using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioPC.Models
{
    public class CarritoItem
    {
        private productos _producto;

        public productos Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public CarritoItem()
        {

        }
        public CarritoItem(productos producto, int cantidad)
        {
            this._producto = producto;
            this._cantidad = cantidad;
        }
    }
}