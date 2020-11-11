using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaxApp.Contracts.Incoming;
using TaxApp.IntegrationTests.Utils;

namespace TaxApp.IntegrationTests
{
    [TestFixture]
    public class MunicipalitiesControllerTests
    {
        private TaxWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new TaxWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetMunicipalities_ShouldReturnOk()
        {
            var result = await _client.GetAsync("/municipalities");
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase("2016-1-1", 0.1)]
        [TestCase("2016-5-2", 0.4)]
        [TestCase("2016-7-10", 0.2)]
        [TestCase("2016-3-16", 0.2)]
        public async Task GetTaxesByDate_ShouldReturnOk(string date, decimal expectedResult)
        {
            var municipalityId = await CreateMunicipality();
            var yearlyTaxId = await CreateTax(municipalityId, new DateTime(2016, 1, 1), new DateTime(2016, 12, 31), 0.2m);
            var monthlyTaxId = await CreateTax(municipalityId, new DateTime(2016, 5, 1), new DateTime(2016, 5, 31), 0.4m);
            var dailyTax1Id = await CreateTax(municipalityId, new DateTime(2016, 1, 1), new DateTime(2016, 1, 1), 0.1m);
            var dailyTax2Id = await CreateTax(municipalityId, new DateTime(2016, 12, 25), new DateTime(2016, 12, 25), 0.1m);

            var response = await _client.GetAsync($"/municipalities/{municipalityId}/date/{date}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsAsync<decimal>();

            Assert.AreEqual(expectedResult, result);

            await _client.DeleteAsync($"/tax/{yearlyTaxId}");
            await _client.DeleteAsync($"/tax/{monthlyTaxId}");
            await _client.DeleteAsync($"/tax/{dailyTax1Id}");
            await _client.DeleteAsync($"/tax/{dailyTax2Id}");
            await _client.DeleteAsync($"/municipalities/{municipalityId}");
        }

        [Test]
        public async Task GetTaxesByInvalidDate_ShouldReturnNotFound()
        {
            var municipalityId = await CreateMunicipality();

            var response = await _client.GetAsync($"/municipalities/{municipalityId}/date/2020-11-11");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            await _client.DeleteAsync($"/municipalities/{municipalityId}");
        }

        private async Task<Guid> CreateMunicipality()
        {
            var municipalityRequest = new MunicipalityRequest()
            {
                Name = Guid.NewGuid().ToString(),
            };

            StringContent municipalityData = new StringContent(JsonConvert.SerializeObject(municipalityRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/municipalities", municipalityData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            return await response.Content.ReadAsAsync<Guid>();
        }

        private async Task<Guid> CreateTax(Guid municipalityId, DateTime PeriodStartDate, DateTime PeriodEndDate, decimal Value)
        {
            var taxRequest = new TaxRequest()
            {
                Value = Value,
                PeriodStartDate = PeriodStartDate,
                PeriodEndDate = PeriodEndDate,
                MunicipalityId = municipalityId
            };

            StringContent taxData = new StringContent(JsonConvert.SerializeObject(taxRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/taxes", taxData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            return await response.Content.ReadAsAsync<Guid>();
        }
    }
}