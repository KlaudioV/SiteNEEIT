using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEEIT.Models
{
    public class Membros
    {
        public Membros()
        {
            ListaDetalhes = new HashSet<Detalhes>();
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Membro
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório...")]
        [StringLength(40, ErrorMessage = "O {0} não deve ser maior que {1} caracteres...")]
        [RegularExpression("[A-Za-zàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð '-]+", ErrorMessage = "O {0} só aceita letras...")]
        public string Nome { get; set; }

        /// <summary>
        /// Apelido do Membro
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(40, ErrorMessage = "Este campo não pode ter mais de  {1} carateres...")]
        [RegularExpression("[A-Za-zàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð '-]+", ErrorMessage = "O {0} só aceita letras...")]
        public string Apelido { get; set; }

        /// <summary>
        /// Email do Membro
        /// </summary>
        [StringLength(40, MinimumLength = 6, ErrorMessage = "O {0} deve estar compreendido entre {1} e {2} caracteres...")]
        [RegularExpression("[a-z0-9.]+@ipt.pt", ErrorMessage = "Escreva um email do IPT, por favor.")]
        [EmailAddress(ErrorMessage = "Só são aceites emails do IPT")]
        public string Email { get; set; }


        public bool Autorizado { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(20)]
        public string Cargo { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataInicioFuncoes { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFimFuncoes { get; set; }

        public ICollection<Detalhes> ListaDetalhes { get; set; }
    }
}
