using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Responses;
using TaxApp.Services.Services;

namespace TaxApp.Controllers
{
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxesService _taxesService;

        public TaxesController(ITaxesService taxesService)
        {
            _taxesService = taxesService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TaxResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return new OkObjectResult(await _taxesService.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaxResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _taxesService.GetAll());
        }
    }
}
