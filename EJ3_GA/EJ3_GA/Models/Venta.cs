using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ3_GA.Models
{
    public class Venta
    {
        public int? Cajero { get; set; }
        public int? Maquina { get; set; }
        public int? Producto { get; set; }

        public virtual Cajeros Cajeros { get; set; }
        public virtual Maquinas_Registradoras Maquinas_Registradoras { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
