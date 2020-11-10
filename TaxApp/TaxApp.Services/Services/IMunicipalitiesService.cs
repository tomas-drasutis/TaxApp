using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Domain;

namespace TaxApp.Services.Services
{
    public interface IMunicipalitiesService
    {
        Task<Municipality> GetById(Guid id);
        Task<IEnumerable<Municipality>> GetAll();
    }
}
