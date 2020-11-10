using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Entities;

namespace TaxApp.Services.Repositories
{
    public interface IMunicipalitiesRepository
    {
        Task<MunicipalityEntity> GetById(Guid id);
        Task<IEnumerable<MunicipalityEntity>> GetAll();
    }
}
