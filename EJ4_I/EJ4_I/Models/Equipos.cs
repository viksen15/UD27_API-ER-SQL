using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ4_I.Models
{
    public class Equipos
    {
        public Equipos()
        {
            Reserva = new HashSet<Reserva>();
        }

        public char? NumSerie { get; set; }
        public string Nombre { get; set; }
        public int Facultad { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual Facultades Facultades { get; set; }
        
    }
}
