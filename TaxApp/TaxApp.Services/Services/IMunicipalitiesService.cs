using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Contracts.Incoming;
using TaxApp.Models.Domain;

namespace TaxApp.Services.Services
{
    public interface IMunicipalitiesService
    {
        Task<Municipality> GetById(Guid id);
        Task<IEnumerable<Municipality>> GetAll();
        Task<Guid> Create(MunicipalityRequest model);
        Task Delete(Guid id);
        Task<Municipality> Update(Guid id, MunicipalityRequest model);
        Task<decimal> GetTaxByDate(Guid id, DateTime date);
    }
}
