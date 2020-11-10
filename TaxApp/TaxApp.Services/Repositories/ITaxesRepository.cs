using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Entities;

namespace TaxApp.Services.Repositories
{
    public interface ITaxesRepository 
    {
        Task<TaxEntity> GetById(Guid id);
        Task<IEnumerable<TaxEntity>> GetAll();
        Task<Guid> Add(TaxEntity entity);
        Task Delete(Guid id);
        Task<TaxEntity> Update(Guid id, TaxEntity entity);
    }
}
