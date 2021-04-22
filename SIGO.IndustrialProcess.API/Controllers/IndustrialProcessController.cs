using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGO.IndustrialProcess.Application.Services.External;
using SIGO.IndustrialProcess.DataContracts;
using System;
using System.Collections.Generic;

namespace SIGO.IndustrialProcess.API.Controllers
{
    [ApiController]
    [Route("IndustrialProcess")]
    public class IndustrialProcessController : Controller
    {
        public IndustrialProcessController(ILogisticService logisticService, ISAPClient sapClient)
        {
            this.logisticService = logisticService ?? throw new ArgumentNullException(nameof(logisticService));
            this.sapClient = sapClient ?? throw new ArgumentNullException(nameof(sapClient));
        }

        private readonly ILogisticService logisticService;
        private readonly ISAPClient sapClient;

        [HttpGet]
        [Route("Healthcheck")]
        public IActionResult GetHealthcheckStatus()
        {
            return Ok("IndustrialProcess is Healthy");
        }

        [HttpGet]
        [Route("GetLogisticReport")]
        public IActionResult GetLogisticReport()
        {
            try
            {
                List<LogisticReportItem> response = logisticService.GetLogisticReportAsync();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        //[HttpGet]
        //[Route("GetEmployeesReport")]
        //public async Task<IActionResult> GetEmployeesReport()
        //{
        //    try
        //    {
        //        List<EmployeeReportItem> response = await regulatoryNormsService.CheckRegulatoryNormsUpdateAsync();

        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);

        //    }
        //}

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