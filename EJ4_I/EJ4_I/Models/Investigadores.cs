using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ4_I.Models
{
    public class Investigadores
    {
        public Investigadores()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string? DNI { get; set; }
        public string NomApels { get; set; }
        public int Facultad { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual Facultades Facultades { get; set; }
    }
}
