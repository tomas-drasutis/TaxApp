using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Responses;

namespace TaxApp.Services.Services.Implementations
{
    public class MunicipalitiesService : IMunicipalitiesService
    {
        public Task<IEnumerable<MunicipalityResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MunicipalityResponse> GetById(Guid municipalityId)
        {
            throw new NotImplementedException();
        }
    }
}
