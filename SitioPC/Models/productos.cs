using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SitioPC.Models
{
    public class productos
    {        
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Procesador")]
        public string procesador { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Gráficos")]
        public string graficos { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RAM")]
        public string ram { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Pantalla")]
        public string pantalla { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Almacenamiento")]
        public string almacenamiento { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Bateria")]
        public string bateria { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Sistema Operativo")]
        public string so { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Audio")]
        public string audio { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Puertos")]
        public string puertos { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Conectividad")]
        public string conectividad { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Precio")]
        public decimal? precio { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Existencias")]
        public string existencias { get; set; }
        
        [Display(Name = "Img")]
        public byte[] img { get; set; }

    }
}