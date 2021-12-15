using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class  Rol
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
