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
    public class PSUControllerIntegrationTests
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
        public async Task Get_All_PSUs_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_PSUs_ShouldReturnExistingGPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");

            var result = await response.Content.ReadAsStringAsync();
            var psus = JsonConvert.DeserializeObject<List<GetPSUDto>>(result);

            var psu = psus[0];

            PSUAsserts(psu);
        }

        [TestMethod]
        public async Task Get_PSU_By_Id_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");
            var result = await response.Content.ReadAsStringAsync();
            var psus = JsonConvert.DeserializeObject<List<GetPSUDto>>(result);
            var psu = psus[0];

            response = await client.GetAsync($"/api/v1/PSU/{psu.PowerUnitId}");
            result = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_PSU_By_Id_ShouldReturnExistingPSU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");
            var result = await response.Content.ReadAsStringAsync();
            var psus = JsonConvert.DeserializeObject<List<GetPSUDto>>(result);
            var psu = psus[0];

            response = await client.GetAsync($"/api/v1/PSU/{psu.PowerUnitId}");
            result = await response.Content.ReadAsStringAsync();
            var testPsu = JsonConvert.DeserializeObject<GetPSUDto>(result);

            PSUAsserts(testPsu);
        }

        [TestMethod]
        public async Task Post_PSU_ShouldReturnCreatedResponse()
        {
            var psu = new CreatePSUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Power = 100,
                Modularity = "IntegrationTest",
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/PSU", new StringContent(JsonConvert.SerializeObject(psu), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Post_PSU_ShouldReturnCreatedPSU()
        {
            var psu = new CreatePSUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Power = 100,
                Modularity = "IntegrationTest",
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/PSU", new StringContent(JsonConvert.SerializeObject(psu), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var psuTest = JsonConvert.DeserializeObject<GetPSUDto>(result);

            Assert.AreEqual(psu.Make, psuTest.Make);
            Assert.AreEqual(psu.Model, psuTest.Model);
            Assert.AreEqual(psu.Price, psuTest.Price);
            Assert.AreEqual(psu.Image, psuTest.Image);
            Assert.AreEqual(psu.Power, psuTest.Power);
            Assert.AreEqual(psu.Modularity, psuTest.Modularity);
        }

        [TestMethod]
        public async Task Put_PSU_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");
            var result = await response.Content.ReadAsStringAsync();
            var psus = JsonConvert.DeserializeObject<List<GetPSUDto>>(result);
            var psuId = psus[0].PowerUnitId;
            var psu = new CreatePSUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Power = 100,
                Modularity = "IntegrationTest",
            };
            response = await client.PutAsync($"/api/v1/PSU/{psuId}", new StringContent(JsonConvert.SerializeObject(psu), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.OK == response.StatusCode);
        }

        [TestMethod]
        public async Task Put_PSU_ShouldReturnUpdatedPSU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");
            var result = await response.Content.ReadAsStringAsync();
            var psus = JsonConvert.DeserializeObject<List<GetPSUDto>>(result);
            var psuId = psus[0].PowerUnitId;
            var psu = new CreatePSUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Power = 100,
                Modularity = "IntegrationTest",
            };
            response = await client.PutAsync($"/api/v1/PSU/{psuId}", new StringContent(JsonConvert.SerializeObject(psu), Encoding.UTF8, "application/json"));
            result = await response.Content.ReadAsStringAsync();
            var psuTest = JsonConvert.DeserializeObject<GetPSUDto>(result);

            Assert.AreEqual(psu.Make, psuTest.Make);
            Assert.AreEqual(psu.Model, psuTest.Model);
            Assert.AreEqual(psu.Price, psuTest.Price);
            Assert.AreEqual(psu.Image, psuTest.Image);
            Assert.AreEqual(psu.Power, psuTest.Power);
            Assert.AreEqual(psu.Modularity, psuTest.Modularity);
        }

        [TestMethod]
        public async Task Delete_PSU_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/PSU");
            var result = await response.Content.ReadAsStringAsync();
            var psus = JsonConvert.DeserializeObject<List<GetPSUDto>>(result);
            var psuId = psus[0].PowerUnitId;

            response = await client.DeleteAsync($"/api/v1/PSU/{psuId}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task Delete_PSU_ShouldReturnNotFoundResponse()
        {
            var client = _factory.CreateClient();
            var psuId = Guid.NewGuid();
            var response = await client.DeleteAsync($"/api/v1/PSU/{psuId}");

            Assert.IsTrue(HttpStatusCode.NotFound == response.StatusCode);
        }

        private static void PSUAsserts(GetPSUDto psu)
        {
            Assert.AreEqual("Corsair", psu.Make);
            Assert.AreEqual("TX750", psu.Model);
            Assert.AreEqual(150, psu.Price);
            Assert.AreEqual("img4", psu.Image);
            Assert.AreEqual(750, psu.Power);
            Assert.AreEqual("Non-Modular", psu.Modularity);
        }
    }
}
