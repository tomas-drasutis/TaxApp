using System;
using System.Collections.Generic;
using System.Text;
using TaxApp.Models.Requests;

namespace TaxApp.Models.Responses
{
    public class MunicipalityResponse : MunicipalityRequest
    {
        public Guid Id { get; set; }
    }
}
