using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_Beatriz.Models;

namespace TCC_Beatriz.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View(new DataContext().Cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Cliente.Find(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Cliente.Add(cliente);
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Cliente.Find(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                // TODO: Add update logic here
                DataContext dataContext = new DataContext();
                dataContext.Cliente.Add(cliente);
                dataContext.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            DataContext dataContext = new DataContext();
            return View(dataContext.Cliente.Find(id));
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                DataContext dataContext = new DataContext();
                dataContext.Entry(cliente).State = System.Data.Entity.EntityState.Deleted;
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
