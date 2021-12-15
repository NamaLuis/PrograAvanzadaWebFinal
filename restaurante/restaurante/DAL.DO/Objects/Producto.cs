using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
