using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Contracts.Incoming;
using TaxApp.Models.Domain;

namespace TaxApp.Services.Services
{
    public interface ITaxesService
    {
        Task<Tax> GetById(Guid id);
        Task<IEnumerable<Tax>> GetAll();
        Task<Guid> Create(TaxRequest model);
        Task Delete(Guid id);
        Task<Tax> Update(Guid id, TaxRequest model);
    }
}
