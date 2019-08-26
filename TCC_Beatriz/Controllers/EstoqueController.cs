using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class EstoqueController : Controller
    {
        // GET: Estoque
        public ActionResult Index()
        {
            return View(new DataContext().HistoricosMovimentoEstoque.ToList());
        }

        // GET: Estoque/Details/5
        public ActionResult Details(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.HistoricosMovimentoEstoque.Find(id));
        }

        // GET: Estoque/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = new DataContext().Produtos.Select(s => new SelectListItem { Text = s.Nome, Value = s.Id.ToString() }).ToList();
            return View();
        }

        // POST: Estoque/Create
        [HttpPost]
        public ActionResult Create(HistoricoEstoque historicoEstoque)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.HistoricosMovimentoEstoque.Add(historicoEstoque);
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estoque/Edit/5
        public ActionResult Edit(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.HistoricosMovimentoEstoque.Find(id));
        }

        // POST: Estoque/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HistoricoEstoque historicoEstoque)
        {
            try
            {
                // TODO: Add update logic here

                DataContext dataContext = new DataContext();
                dataContext.HistoricosMovimentoEstoque.Add(historicoEstoque);
                dataContext.Entry(historicoEstoque).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estoque/Delete/5
        public ActionResult Delete(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.HistoricosMovimentoEstoque.Find(id));
        }

        // POST: Estoque/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HistoricoEstoque historicoEstoque)
        {
            try
            {
                // TODO: Add delete logic here
                DataContext dataContext = new DataContext();
                dataContext.Entry(historicoEstoque).State = System.Data.Entity.EntityState.Deleted;
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
