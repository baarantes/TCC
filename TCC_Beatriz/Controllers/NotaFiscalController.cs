using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class NotaFiscalController : Controller
    {
        // GET: NotaFiscal
        public ActionResult Imprimir(int id)
        {
            DataContext dataContext = new DataContext();
            Pedido pedido = dataContext.Pedidos.Find(id);
            ViewBag.Pedido = pedido;
            ViewBag.Cliente = dataContext.Cliente.Where(w => w.CPF == pedido.CPFCliente).FirstOrDefault();
            ViewBag.ItensPedido = dataContext.ItensPedido.Where(w => w.PedidoId == id).ToList();
            ViewBag.Pagamento = dataContext.Pagamentos.Where(w => w.PedidoId == id).FirstOrDefault();

            return View();
        }
    }
}