using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
