using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class TipoSubscricao
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome da subscrição"), MaxLength(25)]
        [DisplayName("Nome Subscrição")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o valor de inscrição")]        
        [DisplayName("Taxa de Inscrição")]
        public int TaxaInscricao { get; set; }

        [Required(ErrorMessage = "Informe a duração em meses")]
        [Range(0,12)]
        [DisplayName("Duracão")]
        public byte DuracaoEmMeses { get; set; }

        [DisplayName("Desconto (%)")]
        [Range(0,100)]
        public byte PercentualDesconto { get; set; }
        
        public TipoSubscricao()
        {
            Id = new Guid();
        }
    }
}