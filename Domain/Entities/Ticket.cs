using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Domain.Entities
{
    public class Ticket
    {
        // PK
        public Guid TicketId { get; set; }
        // FK
        public int FuncionId { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }

        //FUNCION ASOCIADA AL TKT
        public virtual Funcion funcion { get; set; }
    }
}
