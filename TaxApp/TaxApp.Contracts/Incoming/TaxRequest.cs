using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaxApp.Contracts.Incoming
{
    public class TaxRequest
    {
        [JsonRequired]
        public DateTime PeriodStartDate { get; set; }

        [JsonRequired]
        public DateTime PeriodEndDate { get; set; }

        [JsonRequired, Range(0.0, 99.99)]
        public decimal Value { get; set; }

        [JsonRequired]
        public Guid MunicipalityId { get; set; }
    }
}
