using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genero
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a descrição do genéro"), MaxLength(60)]
        [DisplayName("Genéro")]
        public string Descricao { get; set; }

        public Genero()
        {
            Id = Guid.Empty;
        }
    }

}