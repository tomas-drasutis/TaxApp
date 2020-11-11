using System;

namespace TaxApp.Contracts.Outgoing
{
    public class TaxResponse
    {
        public Guid Id { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public decimal Value { get; set; }
        public Guid MunicipalityId { get; set; }
    }
}
