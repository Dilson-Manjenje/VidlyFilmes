using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels 
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public IEnumerable<TipoSubscricao> TiposSubscricao { get; set; }

        public ClienteViewModel()
        {

        }
        public ClienteViewModel(Cliente cliente)
        {
            Cliente = cliente;
        }

    }
}