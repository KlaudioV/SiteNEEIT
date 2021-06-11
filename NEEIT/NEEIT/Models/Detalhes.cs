using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEEIT.Models
{
    public class Detalhes
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string NomeAcao { get; set; }
        

        [Timestamp]
        public DateTime DataAcao { get; set; }

        [ForeignKey(nameof(Membro))]
        public int MembroFK { get; set; }
        public virtual Membros Membro { get; set; }

        [ForeignKey(nameof(Evento))]
        public int EventoFK { get; set; }
        public virtual Eventos Evento { get; set; }

    }
}
