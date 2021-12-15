using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Factura = new HashSet<Factura>();
        }

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public double Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdPuesto { get; set; }
        public int IdRol { get; set; }

        public virtual Puesto IdPuestoNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
