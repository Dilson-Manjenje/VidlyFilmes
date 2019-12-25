using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _dbContext;        
        public ClientesController()
        {
            _dbContext = new ApplicationDbContext();            
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        
        public ActionResult Index()
        {
            var clientes = _dbContext.Clientes.Include(c => c.TipoSubscricao)
                                              .OrderBy(c => c.Nome)
                                              .ToList();

            var viewModel = new List<ClienteViewModel>();
            clientes.ForEach( cliente => viewModel.Add(new ClienteViewModel(cliente)) );

            ViewBag.ReturnUrl = "Index";

            return View(viewModel);
        }
        
        public ActionResult MostrarDetalhe(Guid? id)
        {
            if ( id == Guid.Empty || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var cliente = _dbContext.Clientes.Include(c => c.TipoSubscricao).SingleOrDefault(c => c.Id == id.Value);
            
            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteViewModel(cliente);

            ViewBag.ReturnUrl = "MostrarDetalhe";
            return View(viewModel);
        }

        
        public ActionResult MostrarNovo()
        {
            var viewModel = new ClienteViewModel();
            viewModel.TiposSubscricao = _dbContext.TipoSubscricao.ToList().OrderBy( s => s.DuracaoEmMeses );
            //ViewBag.ListTipoSubscricao = new SelectList(_dbContext.TipoSubscricao.ToList().OrderBy( s => s.DuracaoEmMeses ), "Id", "Nome");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.TiposSubscricao = _dbContext.TipoSubscricao.ToList().OrderBy(s => s.DuracaoEmMeses);
                return View("MostrarNovo", viewModel);                
            }

            var cliente = new Cliente();

            viewModel.Cliente.Id = Guid.NewGuid();
            cliente = viewModel.Cliente;

            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult MostrarEditar(Guid? id, string returnUrl)
        {
            if (id == Guid.Empty || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var clienteRegistado = _dbContext.Clientes.Include(c => c.TipoSubscricao).SingleOrDefault(c => c.Id == id.Value);

            if (clienteRegistado == null)
                return HttpNotFound();

            var viewModel = new ClienteViewModel()
            {
                Cliente = clienteRegistado,
                TiposSubscricao = _dbContext.TipoSubscricao.ToList().OrderBy(s => s.DuracaoEmMeses)
            };

            ViewBag.ReturnUrl = returnUrl;
            return View(viewModel);
        }

        // Usar o nome do parametro como ClienteViewModel fez com que valores enviados pelo form estejam nulo, o MVC não fazia o bind pelo nome
        //  se usar parametro for tipo Cliente o nome deve ser cliente, ser usar tipo ClienteViewModel nome deve ser viewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(ClienteViewModel viewModel)  
        {
            if (!ModelState.IsValid)
            {
                viewModel.TiposSubscricao = _dbContext.TipoSubscricao.ToList().OrderBy(s => s.DuracaoEmMeses);
                return View("MostrarEditar", viewModel);
            }

            var clienteRegistado = _dbContext.Clientes.Include(c => c.TipoSubscricao).SingleOrDefault(c => c.Id == viewModel.Cliente.Id);

            if (clienteRegistado == null)
                return HttpNotFound();


            // TODO: refactoar com automapper
            //clienteRegistado = viewModel.Cliente;
            clienteRegistado.Nome = viewModel.Cliente.Nome;
            clienteRegistado.DataNascimento = viewModel.Cliente.DataNascimento;
            clienteRegistado.IsInscritoNews = viewModel.Cliente.IsInscritoNews;
            clienteRegistado.TipoSubscricaoId = viewModel.Cliente.TipoSubscricaoId;

            //_dbContext.Clientes.Attach(clienteRegistado);
            //_dbContext.Entry(clienteRegistado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");            
            //return Redirect(returnUrl);
        }
       
        public ActionResult MostrarExcluir(Guid? id)
        {
            if (id == Guid.Empty || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var clienteRegistado = _dbContext.Clientes.Include(c => c.TipoSubscricao).SingleOrDefault(c => c.Id == id.Value);

            if (clienteRegistado == null)
                return HttpNotFound();

            var viewModel = new ClienteViewModel()
            {
                Cliente = clienteRegistado,
                TiposSubscricao = _dbContext.TipoSubscricao.ToList().OrderBy(s => s.DuracaoEmMeses)
            };

            return View(viewModel);
        }
        
        //[HttpPost, ActionName("Excluir")]
        //[ValidateAntiForgeryToken]
        public ActionResult Excluir(Guid? id)
        {
            if (id == Guid.Empty || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var clienteRegistado = _dbContext.Clientes.Include(c => c.TipoSubscricao).SingleOrDefault(c => c.Id == id.Value);

            if (clienteRegistado == null)
                return HttpNotFound();

            _dbContext.Clientes.Remove(clienteRegistado);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
     
    }
}