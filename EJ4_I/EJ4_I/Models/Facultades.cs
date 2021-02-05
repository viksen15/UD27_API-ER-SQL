using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ4_I.Models
{
    public class Facultades
    {
        public Facultades()
        {
            Equipos = new HashSet<Equipos>();
            Investigadores = new HashSet<Investigadores>();
        }

        public int? Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<Investigadores> Investigadores { get; set; }
    }
}
