using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Contracts.Outgoing;
using TaxApp.Models.Domain;
using TaxApp.Services.Repositories;

namespace TaxApp.Services.Services.Implementations
{
    public class MunicipalitiesService : IMunicipalitiesService
    {
        private readonly IMunicipalitiesRepository _municipalitiesRepository;
        private readonly IMapper _mapper;

        public MunicipalitiesService(IMunicipalitiesRepository municipalitiesRepository, IMapper mapper)
        {
            _municipalitiesRepository = municipalitiesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Municipality>> GetAll()
        {
            return _mapper.Map<IEnumerable<Municipality>>(await _municipalitiesRepository.GetAll());
        }

        public async Task<Municipality> GetById(Guid id)
        {
            return _mapper.Map<Municipality>(await _municipalitiesRepository.GetById(id));
        }
    }
}
