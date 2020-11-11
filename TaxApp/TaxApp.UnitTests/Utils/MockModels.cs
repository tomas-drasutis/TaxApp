using System;
using System.Collections.Generic;
using TaxApp.Contracts.Incoming;
using TaxApp.Models.Entities;

namespace TaxApp.UnitTests.Utils
{
    public static class MockModels
    {
        public static MunicipalityEntity GetMunicipalityEntity()
        {
            return new MunicipalityEntity()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Taxes = GetTaxEntities()
            };
        }

        public static ICollection<TaxEntity> GetTaxEntities()
        {
            return new[]
            {
                new TaxEntity()
                {
                    Id = Guid.NewGuid(),
                    Value = 0.1m,
                    PeriodStartDate = new DateTime(2016, 1, 1),
                    PeriodEndDate = new DateTime(2016, 12, 31),
                    MunicipalityId =  Guid.Empty
                },
                new TaxEntity()
                {
                    Id = Guid.NewGuid(),
                    Value = 0.4m,
                    PeriodStartDate = new DateTime(2016, 1, 1),
                    PeriodEndDate = new DateTime(2016, 1, 31),
                    MunicipalityId =  Guid.Empty
                }
            };
        }

        public static TaxRequest GetTaxRequest()
        {
            return new TaxRequest()
            {
                Value = 0.1m,
                PeriodStartDate = new DateTime(2016, 1, 1),
                PeriodEndDate = new DateTime(2016, 12, 31),
                MunicipalityId = Guid.Empty
            };
        }
    }
}
