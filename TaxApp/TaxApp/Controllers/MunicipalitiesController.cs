using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxApp.Models.Responses;
using TaxApp.Services.Services;

namespace TaxApp.Controllers
{
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [ApiController]
    [Route("[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IMunicipalitiesService _municipalitiesService;

        public MunicipalitiesController(IMunicipalitiesService municipalitiesService)
        {
            _municipalitiesService = municipalitiesService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(MunicipalityResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return new OkObjectResult(await _municipalitiesService.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MunicipalityResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _municipalitiesService.GetAll());
        }
    }
}
