using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ1_PyP.Models
{
    public class Piezas
    {
        public Piezas()
        {
            Suministra = new HashSet<Suministra>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Suministra> Suministra { get; set; }
    }
}
