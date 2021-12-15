using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Factura = new HashSet<Factura>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public long Cantidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int IdProveedor { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
