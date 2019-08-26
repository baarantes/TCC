using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class PedidoController : Controller
    {

        public ActionResult ErroPedido(string erro)
        {
            ViewBag.Erro = erro;
            return View();
        }
        public ActionResult PedidoConfirmado()
        {
            return View();
        }


        public ActionResult Finalizar(string cpf, string cartaocredito)
        {
            DataContext dataContext = new DataContext();
            
            if (string.IsNullOrEmpty(cpf))
            {
                return RedirectToAction("ErroPedido", new { erro = "Cliente não encontrado, verifique o CPF." });
            }

            Cliente cliente = dataContext.Cliente.Where(w => w.CPF == cpf).FirstOrDefault();

            if (cliente == null )
            {
                return RedirectToAction("ErroPedido", new { erro = "Cliente não encontrado, verifique o CPF."});
            }

            if (cartaocredito == null || string.IsNullOrEmpty(cartaocredito))
            {
                return RedirectToAction("ErroPedido", new { erro = "Cartão de crédito não informado." });
            }

            if (Session["carrinho"] == null)
            {
                return RedirectToAction("ErroPedido", new { erro= "Adicione pelo menos um produto no carrinho." });
            }

            Pedido pedido = new Pedido();
            pedido.CPFCliente = cliente.CPF;
            pedido.Data = DateTime.Now;

            dataContext.Pedidos.Add(pedido);
            dataContext.SaveChanges();

            List<Carrinho> lista = ((List<Carrinho>)Session["carrinho"]);

            foreach (var item in lista)
            {
                ItemPedido itemPedido = new ItemPedido();
                itemPedido.PedidoId = pedido.Id;
                itemPedido.ProdutoId = item.ProdutoId;
                itemPedido.Quantidade = item.Quantidade;

                dataContext.ItensPedido.Add(itemPedido);
            }

            dataContext.SaveChanges();

            Pagamento pagamento = new Pagamento();
            pagamento.Data = pedido.Data;
            pagamento.NumeroCartao = cartaocredito;
            pagamento.PedidoId = pedido.Id;
            pagamento.Valor = 99;

            dataContext.Pagamentos.Add(pagamento);

            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.Data = pedido.Data;
            notaFiscal.PedidoId = pedido.Id;

            dataContext.NotasFiscais.Add(notaFiscal);

            dataContext.SaveChanges();

            Session["carrinho"] = null;

            return RedirectToAction("PedidoConfirmado");
        }

        public ActionResult FecharPedido()
        {
            return View();
        }

        // GET: Pedido
        public ActionResult Index()
        {
            return View(new DataContext().Pedidos.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Pedidos.Find(id));
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(Pedido pedido)
        {
            try
            {
                // TODO: Add insert logic here
                DataContext dataContext = new DataContext();
                dataContext.Pedidos.Add(pedido);
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Produtos.Find(id));
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produto produto)
        {
            try
            {
                // TODO: Add update logic here
                DataContext dataContext = new DataContext();
                dataContext.Produtos.Add(produto);
                dataContext.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Produtos.Find(id));
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produto produto)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Entry(produto).State = System.Data.Entity.EntityState.Deleted;
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
