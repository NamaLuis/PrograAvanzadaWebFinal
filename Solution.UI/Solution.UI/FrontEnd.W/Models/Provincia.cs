using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
