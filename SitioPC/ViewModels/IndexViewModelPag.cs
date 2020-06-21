using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitioPC.Models;
using IdentitySample.Models;

namespace SitioPC.ViewModels
{
    public class IndexViewModelPag : BaseModelo
    {           
        public List<ApplicationUser> Personas { get; set; }
    }
}