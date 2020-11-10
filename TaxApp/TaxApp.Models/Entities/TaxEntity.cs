using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApp.Models.Entities
{
    public class TaxEntity : BaseEntity
    {
        public decimal Value { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        public Guid MunicipalityId { get; set; }
        public virtual MunicipalityEntity Municipality { get; set; }
    }
}
