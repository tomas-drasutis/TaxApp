using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxApp.Contracts.Incoming;
using TaxApp.Models.Domain;
using TaxApp.Models.Entities;
using TaxApp.Services.DomainServices;
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

        public async Task<Guid> Create(MunicipalityRequest model)
        {
            return await _municipalitiesRepository.Add(_mapper.Map<MunicipalityEntity>(model));
        }

        public async Task Delete(Guid id)
        {
            await _municipalitiesRepository.Delete(id);
        }

        public async Task<IEnumerable<Municipality>> GetAll()
        {
            return _mapper.Map<IEnumerable<Municipality>>(await _municipalitiesRepository.GetAll());
        }

        public async Task<Municipality> GetById(Guid id)
        {
            return _mapper.Map<Municipality>(await _municipalitiesRepository.GetById(id));
        }

        public async Task<decimal> GetTaxByDate(Guid id, DateTime date)
        {
            var municipality = await _municipalitiesRepository.GetByIdWithRelated(id);

            var taxesByDate = municipality.Taxes
                .Where(t => t.PeriodStartDate <= date && date <= t.PeriodEndDate)
                .ToList();

            if (!taxesByDate.Any())
            {
                throw new Exception();
            }

            return taxesByDate
                .OrderBy(t => (t.PeriodEndDate - t.PeriodStartDate).Days + 1)
                .First().Value;
        }

        public async Task<Municipality> Update(Guid id, MunicipalityRequest model)
        {
            return _mapper.Map<Municipality>(await _municipalitiesRepository.Update(id, _mapper.Map<MunicipalityEntity>(model)));
        }
    }
}
