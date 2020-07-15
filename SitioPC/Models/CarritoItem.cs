using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioPC.Models
{
    public class CarritoItem
    {
        private productos _producto;
        private int _cantidad;

        public CarritoItem()
        {

        }

        public CarritoItem(productos producto, int cantidad)
        {
            this._producto = producto;
            this._cantidad = cantidad;
        }

        public productos Producto { get => _producto; set => _producto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }        
    }
}