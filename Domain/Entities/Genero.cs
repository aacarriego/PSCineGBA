using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    namespace Domain.Entities
    {
        public class Genero
        {
            // PK
            public int GeneroId { get; set; }

            public string Nombre { get; set; }
            [StringLength(50)]

            public virtual ICollection<Pelicula> Peliculas { get; set; }

            public Genero() { }

        }
    }

}
