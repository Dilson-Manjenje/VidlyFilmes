using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class FilmesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public FilmesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();            
        }
        public ViewResult Index()
        {
            var viewModel = new List<FilmeViewModel>();

            var filmes = _dbContext.Filmes.Include( f => f.Genero )
                                   .OrderBy( f => f.Nome)
                                   .ToList();

            filmes.ForEach(f => viewModel.Add(new FilmeViewModel(f)));
            
            return View(viewModel);
        }

        public ActionResult MostrarDetalhe(Guid? id)
        {
            if (id == Guid.Empty || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var filme = _dbContext.Filmes.Include( f => f.Genero ).SingleOrDefault( fs => fs.Id == id.Value);

            if (filme == null)
                return HttpNotFound();

            var viewModel = new FilmeViewModel(filme);

            return View(viewModel);
        }

        public ActionResult MostrarEditar(Guid? id)
        {
            if (id == Guid.Empty || id == null || !id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var filmeCadastrado = _dbContext.Filmes.Include(f => f.Genero).SingleOrDefault(m => m.Id == id.Value);

            if (filmeCadastrado == null)
                return HttpNotFound();

            var viewModel = new FilmeViewModel()
            {
                Filme = filmeCadastrado,
                Generos = _dbContext.Genero.OrderBy( g => g.Descricao).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(FilmeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Generos = _dbContext.Genero.OrderBy(g => g.Descricao).ToList();
                return View("MostrarEditar", viewModel);
            }

            var filmeRegistado = _dbContext.Filmes.SingleOrDefault(f => f.Id == viewModel.Filme.Id);

            if (filmeRegistado == null)
                return HttpNotFound();

            // TODO: Refactorar com AutoMapper
            filmeRegistado.Nome = viewModel.Filme.Nome;
            filmeRegistado.Descricao = viewModel.Filme.Descricao;
            filmeRegistado.DataLancamento = viewModel.Filme.DataLancamento;
            filmeRegistado.QtdStock = viewModel.Filme.QtdStock;
            filmeRegistado.Imdb = viewModel.Filme.Imdb;
            filmeRegistado.GeneroId = viewModel.Filme.GeneroId;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ViewResult MostrarNovo()
        {           
            ViewBag.Generos = new SelectList(_dbContext.Genero.OrderBy(g => g.Descricao).ToList(),"Id","Descricao");
            
            var viewModel = new FilmeViewModel(new Filme());
            viewModel.Filme.DataLancamento = new DateTime(1900, 01, 01);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(FilmeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Generos = new SelectList(_dbContext.Genero.OrderBy(g => g.Descricao).ToList(), "Id", "Descricao", viewModel.Filme.GeneroId);
                return View("MostrarNovo", viewModel);
            }

            var filmeModel = new Filme();            

            viewModel.Filme.Id = Guid.NewGuid();
            filmeModel = viewModel.Filme;

            _dbContext.Filmes.Add(filmeModel);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");            
        }


        public ActionResult MostrarExcluir(Guid? id)
        {
            if (id == Guid.Empty || id == null || !id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var filmeCadastrado = _dbContext.Filmes.Include(f => f.Genero).SingleOrDefault(m => m.Id == id.Value);

            if (filmeCadastrado == null)
                return HttpNotFound();

            var viewModel = new FilmeViewModel()
            {
                Filme = filmeCadastrado,
                Generos = _dbContext.Genero.OrderBy(g => g.Descricao).ToList()
            };

            return View(viewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Excluir(FilmeViewModel viewModel) // NOTE: Se passar apenas Id deve ser chamado  por queryString
        public ActionResult Excluir(Guid id) // NOTE: Se passar apenas Id deve ser chamado  por queryString
        {
            if (id == Guid.Empty || id == null )
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parametro Inválido.");

            var filmeRegistado = _dbContext.Filmes.SingleOrDefault(f => f.Id == id);

            if (filmeRegistado == null)
                return HttpNotFound();
            
            _dbContext.Filmes.Remove(filmeRegistado);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}