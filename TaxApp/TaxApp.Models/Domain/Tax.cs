using System;

namespace TaxApp.Models.Domain
{
    public class Tax
    {
        public Guid Id { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public decimal Value { get; set; }
        public Guid MunicipalityId { get; set; }
    }
}
