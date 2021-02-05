using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ3_GA.Models
{
    public class Cajeros
    {
        public Cajeros()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
