using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class AwardController : Controller
    {
        //
        // GET: /Award/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Award/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Award/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Award/Create

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

        //
        // GET: /Award/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Award/Edit/5

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

        //
        // GET: /Award/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Award/Delete/5

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
