using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UI.Login.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Ubicacion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
