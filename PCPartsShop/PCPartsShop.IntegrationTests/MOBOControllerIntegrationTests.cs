using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PCPartsShop.Dtos;
using PCPartsShop_WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.IntegrationTests
{
    [TestClass]
    public class MOBOControllerIntegrationTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Get_All_MOBOs_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_MOBOs_ShouldReturnExistingMOBO()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");

            var result = await response.Content.ReadAsStringAsync();
            var mobos = JsonConvert.DeserializeObject<List<GetMOBODto>>(result);

            var mobo = mobos[0];

            MOBOAsserts(mobo);
        }

        [TestMethod]
        public async Task Get_MOBO_By_Id_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");
            var result = await response.Content.ReadAsStringAsync();
            var mobos = JsonConvert.DeserializeObject<List<GetMOBODto>>(result);
            var mobo = mobos[0];

            response = await client.GetAsync($"/api/v1/MOBO/{mobo.ComponentId}");
            result = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_MOBO_By_Id_ShouldReturnExistingMOBO()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");
            var result = await response.Content.ReadAsStringAsync();
            var mobos = JsonConvert.DeserializeObject<List<GetMOBODto>>(result);
            var mobo = mobos[0];

            response = await client.GetAsync($"/api/v1/MOBO/{mobo.ComponentId}");
            result = await response.Content.ReadAsStringAsync();
            var testMobo = JsonConvert.DeserializeObject<GetMOBODto>(result);

            MOBOAsserts(testMobo);
        }

        [TestMethod]
        public async Task Post_MOBO_ShouldReturnCreatedResponse()
        {
            var mobo = new CreateMOBODto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryType = "IntegrationTest",
                Chipset = "IntegrationTest",
                Format = "IntegrationTest",
                Socket = "IntegrationTest",
                HighestFrequencySupported = 100,
                LowestFrequencySupported = 0,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/MOBO", new StringContent(JsonConvert.SerializeObject(mobo), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Post_MOBO_ShouldReturnCreatedMOBO()
        {
            var mobo = new CreateMOBODto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryType = "IntegrationTest",
                Chipset = "IntegrationTest",
                Format = "IntegrationTest",
                Socket = "IntegrationTest",
                HighestFrequencySupported = 100,
                LowestFrequencySupported = 0,
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/MOBO", new StringContent(JsonConvert.SerializeObject(mobo), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var moboTest = JsonConvert.DeserializeObject<GetMOBODto>(result);

            Assert.AreEqual(mobo.Make, moboTest.Make);
            Assert.AreEqual(mobo.Model, moboTest.Model);
            Assert.AreEqual(mobo.Price, moboTest.Price);
            Assert.AreEqual(mobo.Image, moboTest.Image);
            Assert.AreEqual(mobo.Socket, moboTest.Socket);
            Assert.AreEqual(mobo.Format, moboTest.Format);
            Assert.AreEqual(mobo.Chipset, moboTest.Chipset);
            Assert.AreEqual(mobo.LowestFrequencySupported, moboTest.LowestFrequencySupported);
            Assert.AreEqual(mobo.HighestFrequencySupported, moboTest.HighestFrequencySupported);
            Assert.AreEqual(mobo.MemoryType, moboTest.MemoryType);
        }

        [TestMethod]
        public async Task Put_MOBO_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");
            var result = await response.Content.ReadAsStringAsync();
            var mobos = JsonConvert.DeserializeObject<List<GetMOBODto>>(result);
            var moboId = mobos[0].ComponentId;
            var mobo = new CreateMOBODto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryType = "IntegrationTest",
                Chipset = "IntegrationTest",
                Format = "IntegrationTest",
                Socket = "IntegrationTest",
                HighestFrequencySupported = 100,
                LowestFrequencySupported = 0,
            };
            response = await client.PutAsync($"/api/v1/MOBO/{moboId}", new StringContent(JsonConvert.SerializeObject(mobo), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.OK == response.StatusCode);
        }

        [TestMethod]
        public async Task Put_MOBO_ShouldReturnUpdatedMOBO()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");
            var result = await response.Content.ReadAsStringAsync();
            var mobos = JsonConvert.DeserializeObject<List<GetMOBODto>>(result);
            var moboId = mobos[0].ComponentId;
            var mobo = new CreateMOBODto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryType = "IntegrationTest",
                Chipset = "IntegrationTest",
                Format = "IntegrationTest",
                Socket = "IntegrationTest",
                HighestFrequencySupported = 100,
                LowestFrequencySupported = 0,
            };
            response = await client.PutAsync($"/api/v1/MOBO/{moboId}", new StringContent(JsonConvert.SerializeObject(mobo), Encoding.UTF8, "application/json"));
            result = await response.Content.ReadAsStringAsync();
            var moboTest = JsonConvert.DeserializeObject<GetMOBODto>(result);

            Assert.AreEqual(mobo.Make, moboTest.Make);
            Assert.AreEqual(mobo.Model, moboTest.Model);
            Assert.AreEqual(mobo.Price, moboTest.Price);
            Assert.AreEqual(mobo.Image, moboTest.Image);
            Assert.AreEqual(mobo.Socket, moboTest.Socket);
            Assert.AreEqual(mobo.Format, moboTest.Format);
            Assert.AreEqual(mobo.Chipset, moboTest.Chipset);
            Assert.AreEqual(mobo.LowestFrequencySupported, moboTest.LowestFrequencySupported);
            Assert.AreEqual(mobo.HighestFrequencySupported, moboTest.HighestFrequencySupported);
            Assert.AreEqual(mobo.MemoryType, moboTest.MemoryType);
        }

        [TestMethod]
        public async Task Delete_MOBO_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/MOBO");
            var result = await response.Content.ReadAsStringAsync();
            var mobos = JsonConvert.DeserializeObject<List<GetMOBODto>>(result);
            var moboId = mobos[0].ComponentId;

            response = await client.DeleteAsync($"/api/v1/MOBO/{moboId}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task Delete_MOBO_ShouldReturnNotFoundResponse()
        {
            var client = _factory.CreateClient();
            var moboId = Guid.NewGuid();
            var response = await client.DeleteAsync($"/api/v1/MOBO/{moboId}");

            Assert.IsTrue(HttpStatusCode.NotFound == response.StatusCode);
        }

        private static void MOBOAsserts(GetMOBODto mobo)
        {
            Assert.AreEqual("MSI", mobo.Make);
            Assert.AreEqual("MPG", mobo.Model);
            Assert.AreEqual(155.89, mobo.Price);
            Assert.AreEqual("img3", mobo.Image);
            Assert.AreEqual("AM4", mobo.Socket);
            Assert.AreEqual("ATX", mobo.Format);
            Assert.AreEqual("B550", mobo.Chipset);
            Assert.AreEqual(2133, mobo.LowestFrequencySupported);
            Assert.AreEqual(3200, mobo.HighestFrequencySupported);
            Assert.AreEqual("DDR4", mobo.MemoryType);
        }
    }
}
