using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaxApp.Models.Entities;

namespace TaxApp.Persistance
{
    public interface IDatabaseContext
    {
        DbSet<TaxEntity> Taxes { get; set; }
        DbSet<MunicipalityEntity> Municipalities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken CancellationToken = default);
    }
}
