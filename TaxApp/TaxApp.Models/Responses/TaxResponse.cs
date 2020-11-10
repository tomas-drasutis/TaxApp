using System;
using TaxApp.Models.Requests;

namespace TaxApp.Models.Responses
{
    public class TaxResponse : TaxRequest
    {
        public Guid Id { get; set; }
    }
}
