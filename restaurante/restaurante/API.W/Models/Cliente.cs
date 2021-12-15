using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
        }

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Idprovincia { get; set; }

        public virtual Provincia IdprovinciaNavigation { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
