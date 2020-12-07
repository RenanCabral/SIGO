using Microsoft.AspNetCore.Mvc;
using SIGO.RegulatoryNorms.Application.Services;
using SIGO.RegulatoryNorms.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.API.Controllers
{
    [ApiController]
    [Route("RegulatoryNorms")]
    public class RegulatoryNormController : Controller
    {

        public RegulatoryNormController(IRegulatoryNormsService regulatoryNormsService, IExternalRegulatoryNormsService externalRegulatoryNormsService)
        {
            this.regulatoryNormsService = regulatoryNormsService ?? throw new ArgumentNullException(nameof(regulatoryNormsService));
        }

        private readonly IRegulatoryNormsService regulatoryNormsService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<RegulatoryNorm> response = await regulatoryNormsService.GetAllAsync();

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet]
        public async Task<IActionResult> CheckRegulatoryNormsUpdateAsync()
        {
            try
            {
                List<RegulatoryNorm> response = await regulatoryNormsService.GetAllAsync();

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}