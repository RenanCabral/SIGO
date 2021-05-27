using Microsoft.AspNetCore.Cors;
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
        [Route("Healthcheck")]
        public IActionResult GetHealthcheckStatus()
        {
            return Ok("RegulatoryNormsController is Healthy");
        }

        [HttpGet]
        [Route("healthcheck/rabbitmq/publish")]
        public IActionResult GetRabbitMQHeakthCheckStatus()
        {
            try
            {
                this.regulatoryNormsService.PublishHealthCheckMessage();
                return Ok("Message has been published successfuly.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error to publish message " + ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetAll")]
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
        [Route("GetNorms")]
        public async Task<IActionResult> GetNormsByFilterAsync([FromQuery] RegulatoryNormsFilter filter)
        {
            try
            {
                List<RegulatoryNorm> response = await regulatoryNormsService.GetNormsByFilterAsync(filter);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet]
        [Route("CheckUpdates")]
        public async Task<IActionResult> CheckRegulatoryNormsUpdateAsync()
        {
            try
            {
                List<RegulatoryNormUpdate> response = await regulatoryNormsService.CheckRegulatoryNormsUpdateAsync();

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}