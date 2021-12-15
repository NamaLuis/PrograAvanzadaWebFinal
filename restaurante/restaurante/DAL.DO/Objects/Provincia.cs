using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Provincia
    {
        public Provincia()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
