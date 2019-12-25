using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Filme
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome do título"), MaxLength(60)]
        [DisplayName("Título")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string  Descricao { get; set; }

        [DisplayName("Imdb")]
        //[Range(1,10, ErrorMessage = ("Classificação Imdb é um valor de 1 à 10"))]
        public byte Imdb { get; set; }

        [DisplayName("Data de Lançamento")]
        [Required(ErrorMessage = "Informe a Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [DisplayName("Qtd. Stock")]
        [Required(ErrorMessage = "Informe a quantidade em stock")]
        [Range(1, 20, ErrorMessage = ("Quantidade em stock é um valor de 1 à 10"))]
        public byte QtdStock { get; set; }

        public Genero Genero { get; set; }

        [Required(ErrorMessage = "Selecione o genéro")]
        [DisplayName("Genero")]
        public Guid GeneroId { get; set; }
        public Filme()
        {            
            Id = Guid.Empty;
        }
    }
}