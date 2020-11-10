using System.Collections.Generic;

namespace TaxApp.Models.Entities
{
    public class MunicipalityEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<TaxEntity> Taxes { get; set; }
    }
}
