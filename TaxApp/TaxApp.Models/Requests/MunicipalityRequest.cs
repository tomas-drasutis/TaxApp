using System.ComponentModel.DataAnnotations;

namespace TaxApp.Models.Requests
{
    public class MunicipalityRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
