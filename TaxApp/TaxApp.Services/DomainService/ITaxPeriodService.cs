using System;

namespace TaxApp.Services.DomainServices
{
    public interface ITaxPeriodService
    {
        void ValidatePeriod(DateTime startDate, DateTime endDate);
    }
}
