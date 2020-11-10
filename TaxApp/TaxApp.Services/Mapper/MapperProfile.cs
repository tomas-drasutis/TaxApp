using AutoMapper;
using TaxApp.Contracts.Incoming;
using TaxApp.Contracts.Outgoing;
using TaxApp.Models.Domain;
using TaxApp.Models.Entities;

namespace TaxApp.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TaxRequest, Tax>();
            CreateMap<TaxRequest, TaxEntity>();
            CreateMap<Tax, TaxEntity>();
            CreateMap<TaxEntity, Tax>();
            CreateMap<Tax, TaxResponse>();

            CreateMap<MunicipalityRequest, Municipality>();
            CreateMap<MunicipalityRequest, MunicipalityEntity>();
            CreateMap<Municipality, MunicipalityEntity>();
            CreateMap<MunicipalityEntity, Municipality>();
            CreateMap<Municipality, MunicipalityResponse>();
        }
    }
}
