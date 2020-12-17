using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIGO.IndustrialProcess.API.Controllers
{
    public class IndustrialProcessController : Controller
    {
        // GET: IndustrialProcess
        public ActionResult Index()
        {
            return View();
        }

        // GET: IndustrialProcess/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndustrialProcess/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndustrialProcess/Create
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

        // GET: IndustrialProcess/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndustrialProcess/Edit/5
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

        // GET: IndustrialProcess/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndustrialProcess/Delete/5
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