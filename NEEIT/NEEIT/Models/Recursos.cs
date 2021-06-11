using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEEIT.Models
{
    public class Recursos
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public string Designacao { get; set; }

        public string? Valor { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        [ForeignKey(nameof(Evento))]
        public int EventoFK { get; set; }
        public virtual Eventos Evento { get; set; }
    }
}