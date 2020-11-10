using System.ComponentModel.DataAnnotations;

namespace TaxApp.Contracts.Incoming
{
    public class MunicipalityRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
