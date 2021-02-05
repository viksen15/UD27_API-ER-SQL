using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ1_PyP.Models
{
    public class Proveedores
    {
        public Proveedores()
        {
            Suministra = new HashSet<Suministra>();
        }

        public char? Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Suministra> Suministra { get; set; }

    }
}
