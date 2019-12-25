using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.Validation;

namespace Vidly.Models 
{
    public class Cliente
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome completo"), MaxLength(60)]       
        [DisplayName("Nome Completo")]                     
        public string Nome { get; set; }

        [DisplayName("Receber Novidades")]
        public bool IsInscritoNews { get; set; }
        public TipoSubscricao TipoSubscricao { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de subscrição")]
        [DisplayName("Tipo de Subscrição")]
        public Guid TipoSubscricaoId { get; set; }
        
        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Informa a data de nascimento")]
        [MembroMaior16Anos]
        public DateTime DataNascimento { get; set; }

        public Cliente()
        {
            Id = Guid.Empty;
        }
    }
}