using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ1_PyP.Models
{
    public class Suministra
    {
        public int? CodigoPieza { get; set; }
        public char? IdProveedor { get; set; }
        public int Precio { get; set; }

        public virtual Piezas Piezas { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
