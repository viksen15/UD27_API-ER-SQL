using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ3_GA.Models
{
    public class Productos
    {
        public Productos()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
