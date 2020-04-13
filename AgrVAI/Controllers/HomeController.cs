using AgrVAI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgrVAI.Controllers
{
    public class HomeController : Controller
    {
        private abc db = new abc();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaVendas()
        {
            var q = db.Produtos.AsQueryable().Where(x => x.Produto != "");

            return View(q.ToList());
        }

        [HttpGet]
        public ActionResult CadastroVendas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroVendas(Produtos produtos)
        {

            if (ModelState.IsValid)
            {
                produtos.Produto = produtos.Produto;
                produtos.Quantidade = produtos.Quantidade;
                produtos.Valor = produtos.Valor;
                produtos.Vendedor = produtos.Vendedor;
                db.Produtos.Add(produtos);
                db.SaveChanges();
            }

            return RedirectToAction("ListaVendas");
        }

        [HttpGet]
        public ActionResult Remover(int Id)
        {
            var remoevr = db.Produtos.Find(Id);
            db.Produtos.Remove(remoevr);
            Session["Removido"] = "remvido";
            db.SaveChanges();
            return RedirectToAction("ListaVendas");
            
        }

        [HttpGet]
        public ActionResult EditarVenda(int id)
        {
            return View(db.Produtos.Find(id));

        }
        [HttpPost]
        public ActionResult EditarVenda(Produtos produtos)
        {
            db.Produtos.AddOrUpdate(produtos);
            db.SaveChanges();
            return RedirectToAction("ListaVendas");
        }

        [HttpGet]
        public ActionResult Login()
        {
            Usuario model = new Usuario();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario model, FormCollection form)
        {

            model.User = form["user"];
            model.Senha = form["password"];

            if (model.Senha == "1102" && model.User == "nane")
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return View();
            }
        }
    }
}