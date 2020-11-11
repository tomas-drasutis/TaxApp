using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaxApp.Services.Exceptions;
using TaxApp.Services.Mapper;
using TaxApp.Services.Repositories;
using TaxApp.Services.Services;
using TaxApp.Services.Services.Implementations;
using TaxApp.UnitTests.Utils;

namespace TaxApp.UnitTests.ServiceTest
{
    public class MunicipalitiesServiceTests
    {
        private readonly IMunicipalitiesService _municipalitiesService;
        private readonly Mock<IMunicipalitiesRepository> _municipalitiesRepository;

        public MunicipalitiesServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            var mapper = config.CreateMapper();

            _municipalitiesRepository = new Mock<IMunicipalitiesRepository>();
            _municipalitiesService = new MunicipalitiesService(_municipalitiesRepository.Object, mapper);
        }

        [Test]
        public async Task ValidDate_GetTaxByDate_ShouldReturnDailyTax()
        {
            var municipality = MockModels.GetMunicipalityEntity();

            _municipalitiesRepository
                .Setup(e => e.GetByIdWithRelated(Guid.Empty))
                .Returns(Task.FromResult(municipality));

            var expectedTax = municipality.Taxes.Last();

            var actualTaxValue = await _municipalitiesService.GetTaxByDate(Guid.Empty, new DateTime(2016, 1, 30));

            Assert.AreEqual(expectedTax.Value, actualTaxValue);
        }

        [Test]
        public void InvalidDate_GetTaxByDate_ShouldThrow()
        {
            var municipality = MockModels.GetMunicipalityEntity();

            _municipalitiesRepository
                .Setup(e => e.GetByIdWithRelated(Guid.Empty))
                .Returns(Task.FromResult(municipality));

            var expectedTax = municipality.Taxes.Last();

            Assert.ThrowsAsync<NotFoundException>(() => _municipalitiesService.GetTaxByDate(Guid.Empty, new DateTime(2020, 1, 30)));
        }
    }
}
