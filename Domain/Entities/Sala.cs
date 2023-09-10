using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sala
    {
        // PK
        public int SalaId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        //FUNCNIONES DE LA SALA
        public ICollection<Funcion> Funciones { get; set; }

    }
}
