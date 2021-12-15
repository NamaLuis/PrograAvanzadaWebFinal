using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UI.Login.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
