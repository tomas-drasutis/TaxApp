using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Models.Responses;

namespace TaxApp.Services.Services
{
    public interface ITaxesService
    {
        Task<TaxResponse> GetById(Guid id);
        Task<IEnumerable<TaxResponse>> GetAll();
    }
}
