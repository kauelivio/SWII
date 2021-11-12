using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trab03.Dao;
using Trab03.Models;

namespace Trab03.Controllers
{
    public class ContainerController : Controller
    {
        // GET: Container
        public ActionResult Index()
        {
            ContainerDao dao =  new ContainerDao();
            IList<Container> containers = dao.Lista();
            ViewBag.Containers = containers;

            return View();
        }

        // GET: Container/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: Container/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Container/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Container/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Container/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Container/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Container/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
