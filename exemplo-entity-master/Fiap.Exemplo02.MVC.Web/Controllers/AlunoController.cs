using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        //private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastro()
        {
            //Buscar todos os grupos cadastrados

            var lista = _unit.GrupoRepository.Listar();

            ViewBag.grupos = new SelectList(lista, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {
            _unit.AlunoRepository.Cadastro(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno Cadastrado!";

            return RedirectToAction("Cadastro");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            // include -> busca o relacionamento , faz o JOIN
            //var lista = _context.Aluno.Include("Grupo").ToList();

            var lista = _unit.AlunoRepository.Listar();

            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //buscar o objeto(aluno) no banco
            var aluno = _unit.AlunoRepository.Buscar(id);
            //manda o aluno para a view 
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Editar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }

       [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.Excluir(alunoId);
            TempData["msg"] = "Aluno excluido";
            _unit.Salvar();
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            //Busca o aluno no banco por parte do nome
            //var lista = _context.Aluno.Where(a => a.Nome.Contains(nomeBusca)).ToList();
            var lista = _unit.AlunoRepository.BuscaPor(a => a.Nome.Contains(nomeBusca));
            //Retorna para a view Listar com a lista
            return View("Listar",lista);
        }

        //Sobrescrever o método Dispose do controller
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }

    }
}