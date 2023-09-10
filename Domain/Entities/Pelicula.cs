using Domain.Entities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pelicula
    {
        // PK
        public int PeliculaId { get; set; }

        // FK
        public virtual int GeneroId { get; set; }

        public Genero genero { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(255)]
        public string Sinopsis { get; set; }

        [StringLength(100)]
        public string Poster { get; set; }

        [StringLength(100)]
        public string Trailer { get; set; }

        // LISTA DE FUNCIONES DE LA PELICULA
        public virtual ICollection<Funcion> Funciones { get; set; }


    }
}
