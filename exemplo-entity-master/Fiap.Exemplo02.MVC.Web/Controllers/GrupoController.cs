using Fiap.Exemplo02.MVC.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {

        private PortalContext _context = new PortalContext();

        [HttpGet]
        // GET: Grupo
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
            _context.SaveChanges();
            TempData["msg"] = "Grupo e projeto cadastrados!";
            
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _context.Grupo.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {

            var aluno = _context.Grupo.Find(id);

            return View(aluno);
        }

        [HttpPost]
        public ActionResult Editar(Grupo grupo)
        {
            _context.Entry(grupo.Projeto).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            TempData["msg"] = "Grupo e Projeto alterados com sucesso!";

            return RedirectToAction("Listar");
        }

    }
}