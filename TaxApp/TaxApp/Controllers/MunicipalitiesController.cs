using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Contracts.Incoming;
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

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] MunicipalityRequest municipalityRequest)
        {
            return new OkObjectResult(await _municipalitiesService.Create(municipalityRequest));
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _municipalitiesService.Delete(id);

            return new NoContentResult();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        [ProducesResponseType(typeof(MunicipalityResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MunicipalityRequest municipalityRequest)
        {
            return new OkObjectResult(await _municipalitiesService.Update(id, municipalityRequest));
        }
    }
}
