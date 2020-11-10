using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Responses;

namespace TaxApp.Services.Services
{
    public interface IMunicipalitiesService
    {
        Task<MunicipalityResponse> GetById(Guid id);
        Task<IEnumerable<MunicipalityResponse>> GetAll();
    }
}
