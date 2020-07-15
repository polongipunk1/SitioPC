using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioPC.Models
{
    public class ventadetalle
    {
        public int? Id { get; set; }
        public productos productos { get; set; }
        public int? productosId { get; set; }
        public venta venta { get; set; }
        public int? ventaId { get; set; }
        public string nombre { get; set; }
        public int? cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subtotal { get; set; }
    }
}