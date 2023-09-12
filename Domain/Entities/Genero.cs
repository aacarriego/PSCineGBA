using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    namespace Domain.Entities
    {
        public class Genero
        {
            // PK
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int GeneroId { get; set; }

            public string Nombre { get; set; }
            [StringLength(50)]

            public virtual ICollection<Pelicula> Peliculas { get; set; }

            public Genero() { }

        }
    }

}
