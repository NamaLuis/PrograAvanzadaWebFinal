using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
