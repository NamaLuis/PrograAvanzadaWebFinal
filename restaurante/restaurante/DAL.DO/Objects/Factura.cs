using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
