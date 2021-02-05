using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ3_GA.Models
{
    public class Maquinas_Registradoras
    {
        public Maquinas_Registradoras()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public int  Piso { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
