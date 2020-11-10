using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Entities;
using TaxApp.Persistance;

namespace TaxApp.Services.Repositories.Implementations
{
    public class MunicipalitiesRepository : IMunicipalitiesRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public MunicipalitiesRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<MunicipalityEntity>> GetAll()
        {
            return await _databaseContext.Municipalities.ToListAsync();
        }

        public async Task<MunicipalityEntity> GetById(Guid id)
        {
            return await _databaseContext.Municipalities.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
