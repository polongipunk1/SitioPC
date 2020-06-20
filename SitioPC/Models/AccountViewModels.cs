using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
        [Display(Name = "Télefono")]
        public string Telefono { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre de usuario")]
        
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
        [Display(Name = "Télefono")]
        public string Telefono { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}