using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View(new DataContext().Categorias.ToList());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Categorias.Find(id));
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Categorias.Add(categoria);
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Categorias.Find(id));
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categoria categoria)
        {
            try
            {
                // TODO: Add update logic here
                DataContext dataContext = new DataContext();
                dataContext.Categorias.Add(categoria);
                dataContext.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Categorias.Find(id));
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categoria categoria)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Entry(categoria).State = System.Data.Entity.EntityState.Deleted;
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
