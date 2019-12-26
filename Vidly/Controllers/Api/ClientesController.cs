using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class ClientesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public ClientesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _dbContext.Dispose();
        }

        // GET  /api/Clientes/
        public IEnumerable<Cliente> Index()
        {
            
            var clientes = _dbContext.Clientes.Include(c => c.TipoSubscricao)
                                              .OrderBy(c => c.Nome)
                                              .ToList();

            return clientes;
        }

        // GET  /api/Clientes/id
        public Cliente GetCliente(Guid id)
        {
            if ( id == Guid.Empty )
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                            
            var cliente = _dbContext.Clientes.Include(c => c.TipoSubscricao).SingleOrDefault(c => c.Id == id);

            if ( cliente == null )
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cliente;
        }
    }
}
