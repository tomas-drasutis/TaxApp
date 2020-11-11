using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TaxApp.Models.Entities;
using TaxApp.Services.DomainServices;
using TaxApp.Services.Mapper;
using TaxApp.Services.Repositories;
using TaxApp.Services.Services;
using TaxApp.Services.Services.Implementations;
using TaxApp.UnitTests.Utils;

namespace TaxApp.UnitTests.ServiceTest
{
    public class TaxesServiceTests
    {
        private readonly ITaxesService _taxesService;
        private readonly Mock<ITaxesRepository> _taxesRepository;
        private readonly Mock<ITaxPeriodService> _taxPeriodService;

        public TaxesServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            var mapper = config.CreateMapper();

            _taxPeriodService = new Mock<ITaxPeriodService>();
            _taxesRepository = new Mock<ITaxesRepository>();
            _taxesService = new TaxesService(_taxesRepository.Object, _taxPeriodService.Object, mapper);
        }

        [Test]
        public async Task ValidModel_Create_ShouldSucceed()
        {
            var tax = MockModels.GetTaxRequest();
            var testGuid = Guid.NewGuid();

            _taxesRepository
                .Setup(e => e.Add(It.IsAny<TaxEntity>()))
                .Returns(Task.FromResult(testGuid));

            Assert.AreEqual(testGuid, await _taxesService.Create(tax));
        }
    }
}
