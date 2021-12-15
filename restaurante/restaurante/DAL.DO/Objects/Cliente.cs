using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
