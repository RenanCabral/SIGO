using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGO.Consulting.Application.Services.External;
using SIGO.Consulting.DataContracts;

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
        [Route("GetRegulatoryNormsUpdates")]
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