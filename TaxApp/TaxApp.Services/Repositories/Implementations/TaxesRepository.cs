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

        public async Task<Guid> Add(TaxEntity entity)
        {
            var tax = _databaseContext.Taxes.Add(entity);
            await _databaseContext.SaveChangesAsync();

            return tax.Entity.Id;
        }

        public async Task Delete(Guid id)
        {
            var tax = await GetById(id);

            _databaseContext.Taxes.Remove(tax);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaxEntity>> GetAll()
        {
            return await _databaseContext.Taxes.ToListAsync();
        }

        public async Task<TaxEntity> GetById(Guid id)
        {
            var tax = await _databaseContext.Taxes.FirstOrDefaultAsync(e => e.Id == id);

            if (tax == null)
            {
                throw new Exception();
            }

            return tax;
        }

        public async Task<TaxEntity> Update(Guid id, TaxEntity entity)
        {
            var tax = await GetById(id);

            tax.MunicipalityId = entity.MunicipalityId;
            tax.Value = entity.Value;
            tax.PeriodStartDate = entity.PeriodStartDate;
            tax.PeriodEndDate = entity.PeriodEndDate;

            _databaseContext.Taxes.Update(tax);
            await _databaseContext.SaveChangesAsync();

            return tax;
        }
    }
}
