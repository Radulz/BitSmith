using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PCPartsShop.Application.Commands.CPUCommands.CreateCPU;
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
    public class CPUControllerIntegrationTests
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
        public async Task Get_All_CPUs_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_CPUs_ShouldReturnExistingCPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");

            var result = await response.Content.ReadAsStringAsync();
            var cpus = JsonConvert.DeserializeObject<List<GetCPUDto>>(result);

            var cpu = cpus[0];

            CPUAsserts(cpu);
        }

        [TestMethod]
        public async Task Get_CPU_By_Id_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");
            var result = await response.Content.ReadAsStringAsync();
            var cpus = JsonConvert.DeserializeObject<List<GetCPUDto>>(result);
            var cpu = cpus[0];

            response = await client.GetAsync($"/api/v1/CPU/{cpu.ComponentId}");
            result = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_CPU_By_Id_ShouldReturnExistingCPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");
            var result = await response.Content.ReadAsStringAsync();
            var cpus = JsonConvert.DeserializeObject<List<GetCPUDto>>(result);
            var cpu = cpus[0];

            response = await client.GetAsync($"/api/v1/CPU/{cpu.ComponentId}");
            result = await response.Content.ReadAsStringAsync();
            var testCpu = JsonConvert.DeserializeObject<GetCPUDto>(result);

            CPUAsserts(testCpu);
        }

        [TestMethod]
        public async Task Post_CPU_ShouldReturnCreatedResponse()
        {
            var cpu = new CreateCPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                NumberOfCores = 6,
                ThermalDesignPower = 100,
                Socket = "IntegrationTest",
                Frequency = 5.5,
                MemoryFrequency = 1000,
                Technology = 10,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/CPU", new StringContent(JsonConvert.SerializeObject(cpu), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Post_CPU_ShouldReturnCreatedCPU()
        {
            var cpu = new CreateCPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                NumberOfCores = 6,
                ThermalDesignPower = 100,
                Socket = "IntegrationTest",
                Frequency = 5.5,
                MemoryFrequency = 1000,
                Technology = 10,
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/CPU", new StringContent(JsonConvert.SerializeObject(cpu), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var cpuTest = JsonConvert.DeserializeObject<GetCPUDto>(result);

            Assert.AreEqual(cpu.Make, cpuTest.Make);
            Assert.AreEqual(cpu.Model, cpuTest.Model);
            Assert.AreEqual(cpu.Price, cpuTest.Price);
            Assert.AreEqual(cpu.Image, cpuTest.Image);
            Assert.AreEqual(cpu.Frequency, cpuTest.Frequency);
            Assert.AreEqual(cpu.Socket, cpuTest.Socket);
            Assert.AreEqual(cpu.Technology, cpuTest.Technology);
            Assert.AreEqual(cpu.MemoryFrequency, cpuTest.MemoryFrequency);
            Assert.AreEqual(cpu.ThermalDesignPower, cpuTest.ThermalDesignPower);
            Assert.AreEqual(cpu.NumberOfCores, cpuTest.NumberOfCores);
        }

        [TestMethod]
        public async Task Put_CPU_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");
            var result = await response.Content.ReadAsStringAsync();
            var cpus = JsonConvert.DeserializeObject<List<GetCPUDto>>(result);
            var cpuId = cpus[0].ComponentId;
            var cpu = new CreateCPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                NumberOfCores = 6,
                ThermalDesignPower = 100,
                Socket = "IntegrationTest",
                Frequency = 5.5,
                MemoryFrequency = 1000,
                Technology = 10,
            };
            response = await client.PutAsync($"/api/v1/CPU/{cpuId}", new StringContent(JsonConvert.SerializeObject(cpu), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.OK == response.StatusCode);
        }

        [TestMethod]
        public async Task Put_CPU_ShouldReturnUpdatedCPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");
            var result = await response.Content.ReadAsStringAsync();
            var cpus = JsonConvert.DeserializeObject<List<GetCPUDto>>(result);
            var cpuId = cpus[0].ComponentId;
            var cpu = new CreateCPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                NumberOfCores = 6,
                ThermalDesignPower = 100,
                Socket = "IntegrationTest",
                Frequency = 5.5,
                MemoryFrequency = 1000,
                Technology = 10,
            };
            response = await client.PutAsync($"/api/v1/CPU/{cpuId}", new StringContent(JsonConvert.SerializeObject(cpu), Encoding.UTF8, "application/json"));
            result = await response.Content.ReadAsStringAsync();
            var cpuTest = JsonConvert.DeserializeObject<GetCPUDto>(result);

            Assert.AreEqual(cpu.Make, cpuTest.Make);
            Assert.AreEqual(cpu.Model, cpuTest.Model);
            Assert.AreEqual(cpu.Price, cpuTest.Price);
            Assert.AreEqual(cpu.Image, cpuTest.Image);
            Assert.AreEqual(cpu.Frequency, cpuTest.Frequency);
            Assert.AreEqual(cpu.Socket, cpuTest.Socket);
            Assert.AreEqual(cpu.Technology, cpuTest.Technology);
            Assert.AreEqual(cpu.MemoryFrequency, cpuTest.MemoryFrequency);
            Assert.AreEqual(cpu.ThermalDesignPower, cpuTest.ThermalDesignPower);
            Assert.AreEqual(cpu.NumberOfCores, cpuTest.NumberOfCores);
        }

        [TestMethod]
        public async Task Delete_CPU_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/CPU");
            var result = await response.Content.ReadAsStringAsync();
            var cpus = JsonConvert.DeserializeObject<List<GetCPUDto>>(result);
            var cpuId = cpus[1].ComponentId;

            response = await client.DeleteAsync($"/api/v1/CPU/{cpuId}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task Delete_CPU_ShouldReturnNotFoundResponse()
        {
            var client = _factory.CreateClient();
            var cpuId = Guid.NewGuid();
            var response = await client.DeleteAsync($"/api/v1/CPU/{cpuId}");

            Assert.IsTrue(HttpStatusCode.NotFound == response.StatusCode);
        }

        private static void CPUAsserts(GetCPUDto cpu)
        {
            Assert.AreEqual("AMD", cpu.Make);
            Assert.AreEqual("Ryzen 5", cpu.Model);
            Assert.AreEqual(299.99, cpu.Price);
            Assert.AreEqual("no", cpu.Image);
            Assert.AreEqual(5.0, cpu.Frequency);
            Assert.AreEqual("AM4", cpu.Socket);
            Assert.AreEqual(7, cpu.Technology);
            Assert.AreEqual(3200, cpu.MemoryFrequency);
            Assert.AreEqual(65, cpu.ThermalDesignPower);
            Assert.AreEqual(6, cpu.NumberOfCores);
        }
    }
}
