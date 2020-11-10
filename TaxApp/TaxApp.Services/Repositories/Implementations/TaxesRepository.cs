using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Entities;
using TaxApp.Persistance;

namespace TaxApp.Services.Repositories.Implementations
{
    public class TaxesRepository : ITaxesRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public TaxesRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<TaxEntity>> GetAll()
        {
            return await _databaseContext.Taxes.ToListAsync();
        }

        public async Task<TaxEntity> GetById(Guid id)
        {
            return await _databaseContext.Taxes.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
