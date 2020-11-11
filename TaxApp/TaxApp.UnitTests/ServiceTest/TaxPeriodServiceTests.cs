using NUnit.Framework;
using System;
using TaxApp.Services.DomainService.Implementations;
using TaxApp.Services.DomainServices;
using TaxApp.Services.Exceptions;

namespace TaxApp.UnitTests
{
    public class TaxPeriodServiceTests
    {
        private readonly ITaxPeriodService _taxPeriodService;

        public TaxPeriodServiceTests()
        {
            _taxPeriodService = new TaxPeriodService();
        }

        [TestCase(2016, 1, 1, 2016, 12, 31)]
        [TestCase(2016, 5, 1, 2016, 5, 31)]
        [TestCase(2016, 6, 1, 2016, 6, 30)]
        [TestCase(2020, 11, 9, 2020, 11, 15)]
        [TestCase(2016, 1, 1, 2016, 1, 1)]
        [TestCase(2016, 12, 25, 2016, 12, 25)]
        public void DifferentPeriods_ValidatePeriod_ShouldNotThrow(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            Assert.DoesNotThrow(() => _taxPeriodService.ValidatePeriod(new DateTime(startYear, startMonth, startDay), new DateTime(endYear, endMonth, endDay)));
        }

        [TestCase(2016, 12, 31, 2016, 1, 1)]
        [TestCase(2016, 5, 10, 2016, 5, 31)]
        [TestCase(2016, 6, 1, 2016, 6, 2)]
        public void DifferentPeriods_ValidatePeriod_ShouldThrow(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            Assert.Throws<TaxAppValidationException>(() => _taxPeriodService.ValidatePeriod(new DateTime(startYear, startMonth, startDay), new DateTime(endYear, endMonth, endDay)));
        }
    }
}