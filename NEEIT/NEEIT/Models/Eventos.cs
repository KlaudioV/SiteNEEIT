using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEEIT.Models
{
    public class Eventos
    {
        public Eventos()
        {
            ListaRecursos = new HashSet<Recursos>();
            ListaDetalhes = new HashSet<Detalhes>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraFim { get; set; }

        public bool Visibilidade { get; set; }

        public ICollection<Detalhes> ListaDetalhes { get; set; }

        public ICollection <Recursos> ListaRecursos { get; set; }
    }
}
