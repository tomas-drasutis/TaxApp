using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxApp.Models.Responses;

namespace TaxApp.Services.Services.Implementations
{
    public class TaxesService : ITaxesService
    {
        public Task<IEnumerable<TaxResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TaxResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
