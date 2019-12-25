using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FilmeViewModel
    {
        public Filme Filme { get; set; }
        public IEnumerable<Genero> Generos { get; set; }    
        public FilmeViewModel()
        {

        }
        public FilmeViewModel(Filme filme)
        {
            Filme = filme;
        }
    }
}