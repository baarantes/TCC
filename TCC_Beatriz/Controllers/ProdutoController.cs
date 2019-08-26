using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View(new DataContext().Produtos.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Produtos.Find(id));
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new DataContext().Categorias.Select(s => new SelectListItem { Text = s.Nome, Value = s.Id.ToString() }).ToList();

            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Produtos.Add(produto);
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = new DataContext().Categorias.Select(s => new SelectListItem { Text = s.Nome, Value = s.Id.ToString() }).ToList();
            DataContext dataContext = new DataContext();
            return View(dataContext.Produtos.Find(id));
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produto produto)
        {
            try
            {
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

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Produtos.Find(id));
        }

        // POST: Produto/Delete/5
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
