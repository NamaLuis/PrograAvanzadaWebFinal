using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.API.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
