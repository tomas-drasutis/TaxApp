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
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IMunicipalitiesService _municipalitiesService;
        private readonly IMapper _mapper;

        public MunicipalitiesController(IMunicipalitiesService municipalitiesService, IMapper mapper)
        {
            _municipalitiesService = municipalitiesService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(MunicipalityResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return new OkObjectResult(_mapper.Map<MunicipalityResponse>(await _municipalitiesService.GetById(id)));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MunicipalityResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(_mapper.Map<IEnumerable<MunicipalityResponse>>(await _municipalitiesService.GetAll()));
        }
    }
}
