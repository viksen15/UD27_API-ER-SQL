using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2_C.Models
{
    public class Proyectos
    {
        public Proyectos()
        { 
            Asignado_A = new HashSet<Asignado_A>();
        }

        public char? Id { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }

        public virtual ICollection<Asignado_A> Asignado_A { get; set; }
    }
}
