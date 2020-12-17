using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIGO.Consulting.API.Controllers
{
    public class ConsultingController : Controller
    {
        // GET: Consulting
        public ActionResult Index()
        {
            return View();
        }

        // GET: Consulting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consulting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consulting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Consulting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Consulting/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Consulting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consulting/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}