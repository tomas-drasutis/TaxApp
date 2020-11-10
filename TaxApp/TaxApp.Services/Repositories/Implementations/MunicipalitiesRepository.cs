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

        public async Task<Guid> Add(MunicipalityEntity entity)
        {
            var municipality = _databaseContext.Municipalities.Add(entity);
            await _databaseContext.SaveChangesAsync();

            return municipality.Entity.Id;
        }

        public async Task Delete(Guid id)
        {
            var municipality = await GetById(id);

            _databaseContext.Municipalities.Remove(municipality);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MunicipalityEntity>> GetAll()
        {
            return await _databaseContext.Municipalities.ToListAsync();
        }

        public async Task<MunicipalityEntity> GetById(Guid id)
        {
            var municipality = await _databaseContext.Municipalities.FirstOrDefaultAsync(e => e.Id == id);

            if (municipality == null)
            {
                throw new Exception();
            }

            return municipality;
        }

        public async Task<MunicipalityEntity> GetByIdWithRelated(Guid id)
        {
            var municipality = await _databaseContext.Municipalities
                .Include(e=> e.Taxes)
                .FirstOrDefaultAsync(e => e.Id == id); ;

            if (municipality == null)
            {
                throw new Exception();
            }

            return municipality;
        }

        public async Task<MunicipalityEntity> Update(Guid id, MunicipalityEntity entity)
        {
            var municipality = await GetById(id);

            municipality.Name = entity.Name;

            _databaseContext.Municipalities.Update(municipality);
            await _databaseContext.SaveChangesAsync();

            return municipality;
        }
    }
}
