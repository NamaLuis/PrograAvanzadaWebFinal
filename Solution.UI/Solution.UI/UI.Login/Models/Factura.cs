using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UI.Login.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public double Monto { get; set; }
        public double Descuento { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
