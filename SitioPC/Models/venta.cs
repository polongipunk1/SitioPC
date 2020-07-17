using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace SitioPC.Models
{
    public class venta
    {

        public venta()
        {
            this.ventadetalle = new HashSet<ventadetalle>();
        }

        public int? Id { get; set; }
        public DateTime fecha { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public decimal? total { get; set; }
        public string ApplicationUserName { get; set; }
        public virtual ICollection<ventadetalle> ventadetalle { get; set; }
    }
}