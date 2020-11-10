using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Contracts.Outgoing;
using TaxApp.Services.Services;

namespace TaxApp.Controllers
{
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxesService _taxesService;
        private readonly IMapper _mapper;

        public TaxesController(ITaxesService taxesService, IMapper mapper)
        {
            _taxesService = taxesService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TaxResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return new OkObjectResult(_mapper.Map<TaxResponse>(await _taxesService.GetById(id)));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaxResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(_mapper.Map<IEnumerable<TaxResponse>>(await _taxesService.GetAll()));
        }
    }
}
