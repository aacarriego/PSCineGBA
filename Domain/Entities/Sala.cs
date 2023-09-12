using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Sala
    {
        // PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        //FUNCNIONES DE LA SALA
        public ICollection<Funcion> Funciones { get; set; }

    }
}
