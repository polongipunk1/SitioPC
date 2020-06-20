using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Usuario")]        
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Región")]
        public string Region { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Código Postal")]
        public string CP { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}