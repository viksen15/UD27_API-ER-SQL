using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2_C.Models
{
    public class Cientificos
    {
        public Cientificos()
        {
            Asignado_A = new HashSet<Asignado_A>();
        }

        public string? DNI { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Asignado_A> Asignado_A { get; set; }
    }
}
