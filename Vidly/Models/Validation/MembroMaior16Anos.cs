using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Validation
{
    public class MembroMaior16Anos : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var cliente = (Cliente)validationContext.ObjectInstance;

            if (cliente.DataNascimento == null)
                return new ValidationResult("Data de nascimento é obrigatório");

            var idade = DateTime.Today.Year - cliente.DataNascimento.Year;
            return (idade >= 17) ? ValidationResult.Success : new ValidationResult("Cliente deve ser maior de 16 anos!"); ;


        }

    }
}