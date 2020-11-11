using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Entities;

namespace TaxApp.Services.Repositories
{
    public interface IMunicipalitiesRepository
    {
        Task<MunicipalityEntity> GetById(Guid id);
        Task<MunicipalityEntity> GetByIdWithRelated(Guid id);
        Task<IEnumerable<MunicipalityEntity>> GetAll();
        Task<Guid> Add(MunicipalityEntity entity);
        Task Delete(Guid id);
        Task<MunicipalityEntity> Update(Guid id, MunicipalityEntity entity);
    }
}
