using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Domain;

namespace TaxApp.Services.Services
{
    public interface ITaxesService
    {
        Task<Tax> GetById(Guid id);
        Task<IEnumerable<Tax>> GetAll();
    }
}
