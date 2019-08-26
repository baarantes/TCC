using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string busca = "")
        {
            return View(new DataContext().Produtos.Where(w=>w.Nome.ToUpper().Contains(busca.ToUpper()) || w.Categoria.Nome.ToUpper().Contains(busca.ToUpper())).ToList());
        }

        [HttpPost]
        public ActionResult AdicionarCarrinho(int produtoId, int quantidade)
        {
            List<Carrinho> lista = new List<Carrinho>();
            if (Session["carrinho"] == null)
                Session["carrinho"] = new List<Carrinho>();

            DataContext dataContext = new DataContext();

            lista = ((List<Carrinho>)Session["carrinho"]);
            lista.Add(new Carrinho { ProdutoId = produtoId, Quantidade = quantidade, Produto = dataContext.Produtos.Find(produtoId) });

            Session["carrinho"] = lista;

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}