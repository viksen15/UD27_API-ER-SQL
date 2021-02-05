using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2_C.Models
{
    public class Asignado_A
    {
        public string Cientifico { get; set; }
        public char Proyecto { get; set; }

        public Cientificos Cientificos { get; set; }
        public Proyectos Proyectos { get; set; }
    }
}
