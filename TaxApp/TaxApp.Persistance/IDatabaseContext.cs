using Microsoft.EntityFrameworkCore;
using TaxApp.Models.Entities;

namespace TaxApp.Persistance
{
    public interface IDatabaseContext
    {
        DbSet<TaxEntity> Taxes { get; set; }
        DbSet<MunicipalityEntity> Municipalities { get; set; }
    }
}
