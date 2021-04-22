using Microsoft.AspNetCore.Mvc;
using SIGO.Consulting.Application.Services.External;
using SIGO.Consulting.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consulting.API.Controllers
{
    [ApiController]
    [Route("Consulting")]
    public class ConsultingController : Controller
    {
        public ConsultingController(IRegulatoryNormsService regulatoryNormsService)
        {
            this._regulatoryNormsService = regulatoryNormsService ?? throw new ArgumentNullException(nameof(regulatoryNormsService));
        }

        private readonly IRegulatoryNormsService _regulatoryNormsService;

        [HttpGet]
        [Route("Healthcheck")]
        public IActionResult GetHealthcheckStatus()
        {
            return Ok("ConsultingController is Healthy");
        }

        [HttpGet]
        [Route("GetNormsUpdates")]
        public async Task<IActionResult> GetRegulatoryNormsUpdatesAsync()
        {
            try
            {   
                List<RegulatoryNormUpdate> response = await _regulatoryNormsService.GetRegulatoryNormsUpdatesAsync();

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}