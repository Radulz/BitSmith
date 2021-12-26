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
    public class RAMControllerIntegrationTests
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
        public async Task Get_All_RAMs_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_RAMs_ShouldReturnExistingRAM()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");

            var result = await response.Content.ReadAsStringAsync();
            var rams = JsonConvert.DeserializeObject<List<GetRAMDto>>(result);

            var ram = rams[0];

            RAMAsserts(ram);
        }

        [TestMethod]
        public async Task Get_RAM_By_Id_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");
            var result = await response.Content.ReadAsStringAsync();
            var rams = JsonConvert.DeserializeObject<List<GetRAMDto>>(result);
            var ram = rams[0];

            response = await client.GetAsync($"/api/v1/RAM/{ram.ComponentId}");
            result = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_RAM_By_Id_ShouldReturnExistingRAM()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");
            var result = await response.Content.ReadAsStringAsync();
            var rams = JsonConvert.DeserializeObject<List<GetRAMDto>>(result);
            var ram = rams[0];

            response = await client.GetAsync($"/api/v1/RAM/{ram.ComponentId}");
            result = await response.Content.ReadAsStringAsync();
            var testRam = JsonConvert.DeserializeObject<GetRAMDto>(result);

            RAMAsserts(testRam);
        }

        [TestMethod]
        public async Task Post_RAM_ShouldReturnCreatedResponse()
        {
            var ram = new CreateRAMDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Capacity = 8,
                Frequency = 1000,
                Type = "DDR4",
                Voltage = 1.2,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/RAM", new StringContent(JsonConvert.SerializeObject(ram), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Post_RAM_ShouldReturnCreatedRAM()
        {
            var ram = new CreateRAMDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Capacity = 8,
                Frequency = 1000,
                Type = "DDR4",
                Voltage = 1.2,
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/RAM", new StringContent(JsonConvert.SerializeObject(ram), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var ramTest = JsonConvert.DeserializeObject<GetRAMDto>(result);

            Assert.AreEqual(ram.Make, ramTest.Make);
            Assert.AreEqual(ram.Model, ramTest.Model);
            Assert.AreEqual(ram.Price, ramTest.Price);
            Assert.AreEqual(ram.Image, ramTest.Image);
            Assert.AreEqual(ram.Frequency, ramTest.Frequency);
            Assert.AreEqual(ram.Capacity, ramTest.Capacity);
            Assert.AreEqual(ram.Type, ramTest.Type);
            Assert.AreEqual(ram.Voltage, ramTest.Voltage);
        }

        [TestMethod]
        public async Task Put_RAM_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");
            var result = await response.Content.ReadAsStringAsync();
            var rams = JsonConvert.DeserializeObject<List<GetRAMDto>>(result);
            var ramId = rams[0].ComponentId;
            var ram = new CreateRAMDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Capacity = 8,
                Frequency = 1000,
                Type = "DDR4",
                Voltage = 1.2,
            };
            response = await client.PutAsync($"/api/v1/RAM/{ramId}", new StringContent(JsonConvert.SerializeObject(ram), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.OK == response.StatusCode);
        }

        [TestMethod]
        public async Task Put_RAM_ShouldReturnUpdatedRAM()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");
            var result = await response.Content.ReadAsStringAsync();
            var rams = JsonConvert.DeserializeObject<List<GetRAMDto>>(result);
            var ramId = rams[0].ComponentId;
            var ram = new CreateRAMDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                Capacity = 8,
                Frequency = 1000,
                Type = "DDR4",
                Voltage = 1.2,
            };
            response = await client.PutAsync($"/api/v1/RAM/{ramId}", new StringContent(JsonConvert.SerializeObject(ram), Encoding.UTF8, "application/json"));
            result = await response.Content.ReadAsStringAsync();
            var ramTest = JsonConvert.DeserializeObject<GetRAMDto>(result);

            Assert.AreEqual(ram.Make, ramTest.Make);
            Assert.AreEqual(ram.Model, ramTest.Model);
            Assert.AreEqual(ram.Price, ramTest.Price);
            Assert.AreEqual(ram.Image, ramTest.Image);
            Assert.AreEqual(ram.Frequency, ramTest.Frequency);
            Assert.AreEqual(ram.Capacity, ramTest.Capacity);
            Assert.AreEqual(ram.Type, ramTest.Type);
            Assert.AreEqual(ram.Voltage, ramTest.Voltage);
        }

        [TestMethod]
        public async Task Delete_RAM_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/RAM");
            var result = await response.Content.ReadAsStringAsync();
            var rams = JsonConvert.DeserializeObject<List<GetRAMDto>>(result);
            var ramId = rams[0].ComponentId;

            response = await client.DeleteAsync($"/api/v1/RAM/{ramId}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task Delete_RAM_ShouldReturnNotFoundResponse()
        {
            var client = _factory.CreateClient();
            var ramId = Guid.NewGuid();
            var response = await client.DeleteAsync($"/api/v1/RAM/{ramId}");

            Assert.IsTrue(HttpStatusCode.NotFound == response.StatusCode);
        }

        private static void RAMAsserts(GetRAMDto ram)
        {
            Assert.AreEqual("HyperX", ram.Make);
            Assert.AreEqual("Fury", ram.Model);
            Assert.AreEqual(125.5, ram.Price);
            Assert.AreEqual("img5", ram.Image);
            Assert.AreEqual(2400, ram.Frequency);
            Assert.AreEqual("DDR4", ram.Type);
            Assert.AreEqual(1.2, ram.Voltage);
        }
    }
}
