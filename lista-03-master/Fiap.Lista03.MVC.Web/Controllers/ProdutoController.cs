using Fiap.Lista03.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Lista03.MVC.Web.Controllers
{
    public class ProdutoController : Controller
    {

        private Entities _context = new Entities();

        // GET: Produto
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Cadastrar(Produto produto)
        {
            //Adicionando o produto ao banco
            _context.Produtos.Add(produto);
            //Salvando no banco (como se fosse commit)
            _context.SaveChanges();

            TempData["msg"] = "Produto cadastrado com sucesso!";

            return RedirectToAction("Cadastrar");
        }

        public ActionResult Listar()
        {
            //Listando os produtos do banco
            var lista = _context.Produtos.ToList();

            return View(lista);
        }

    }
}