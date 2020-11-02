using Microsoft.AspNetCore.Mvc;
using SIGO.RegulatoryNorms.DataContracts;
using System.Collections.Generic;

namespace SIGO.RegulatoryNorms.API.Controllers
{
    [ApiController]
    [Route("RegulatoryNorms")]
    public class RegulatoryNormController : Controller
    {
        [HttpGet]
        public IEnumerable<RegulatoryNorm> Get()
        {
            return new List<RegulatoryNorm>() 
            {
                new RegulatoryNorm() { Code = "0001", Description = "Norma de segurança de trabalho" },
                new RegulatoryNorm() { Code = "0002", Description = "Norma de segurança ambiental" }
            };
        }
    }
}