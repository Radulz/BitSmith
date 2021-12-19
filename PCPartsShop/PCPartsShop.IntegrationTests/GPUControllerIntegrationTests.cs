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
    public class GPUControllerIntegrationTests
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
        public async Task Get_All_GPUs_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_GPUs_ShouldReturnExistingGPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");

            var result = await response.Content.ReadAsStringAsync();
            var gpus = JsonConvert.DeserializeObject<List<GetGPUDto>>(result);

            var gpu = gpus[0];

            GPUAsserts(gpu);
        }

        [TestMethod]
        public async Task Get_GPU_By_Id_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");
            var result = await response.Content.ReadAsStringAsync();
            var gpus = JsonConvert.DeserializeObject<List<GetGPUDto>>(result);
            var gpu = gpus[0];

            response = await client.GetAsync($"/api/v1/GPU/{gpu.GPUId}");
            result = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_GPU_By_Id_ShouldReturnExistingGPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");
            var result = await response.Content.ReadAsStringAsync();
            var gpus = JsonConvert.DeserializeObject<List<GetGPUDto>>(result);
            var gpu = gpus[0];

            response = await client.GetAsync($"/api/v1/GPU/{gpu.GPUId}");
            result = await response.Content.ReadAsStringAsync();
            var testGpu = JsonConvert.DeserializeObject<GetGPUDto>(result);

            GPUAsserts(testGpu);
        }

        [TestMethod]
        public async Task Post_GPU_ShouldReturnCreatedResponse()
        {
            var gpu = new CreateGPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryCapacity = 8,
                MemoryType = "IntegrationTest",
                Length = 100,
                PowerConsumption = 100,
                Frequency = 1000,
                Technology = 10,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/GPU", new StringContent(JsonConvert.SerializeObject(gpu), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Post_GPU_ShouldReturnCreatedGPU()
        {
            var gpu = new CreateGPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryCapacity = 8,
                MemoryType = "IntegrationTest",
                Length = 100,
                PowerConsumption = 100,
                Frequency = 1000,
                Technology = 10,
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/v1/GPU", new StringContent(JsonConvert.SerializeObject(gpu), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var gpuTest = JsonConvert.DeserializeObject<GetGPUDto>(result);

            Assert.AreEqual(gpu.Make, gpuTest.Make);
            Assert.AreEqual(gpu.Model, gpuTest.Model);
            Assert.AreEqual(gpu.Price, gpuTest.Price);
            Assert.AreEqual(gpu.Image, gpuTest.Image);
            Assert.AreEqual(gpu.Frequency, gpuTest.Frequency);
            Assert.AreEqual(gpu.MemoryCapacity, gpuTest.MemoryCapacity);
            Assert.AreEqual(gpu.Technology, gpuTest.Technology);
            Assert.AreEqual(gpu.MemoryType, gpuTest.MemoryType);
            Assert.AreEqual(gpu.PowerConsumption, gpuTest.PowerConsumption);
            Assert.AreEqual(gpu.Length, gpuTest.Length);
        }

        [TestMethod]
        public async Task Put_GPU_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");
            var result = await response.Content.ReadAsStringAsync();
            var gpus = JsonConvert.DeserializeObject<List<GetGPUDto>>(result);
            var gpuId = gpus[0].GPUId;
            var gpu = new CreateGPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryCapacity = 8,
                MemoryType = "IntegrationTest",
                Length = 100,
                PowerConsumption = 100,
                Frequency = 1000,
                Technology = 10,
            };
            response = await client.PutAsync($"/api/v1/GPU/{gpuId}", new StringContent(JsonConvert.SerializeObject(gpu), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.OK == response.StatusCode);
        }

        [TestMethod]
        public async Task Put_GPU_ShouldReturnUpdatedGPU()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");
            var result = await response.Content.ReadAsStringAsync();
            var gpus = JsonConvert.DeserializeObject<List<GetGPUDto>>(result);
            var gpuId = gpus[0].GPUId;
            var gpu = new CreateGPUDto
            {
                Make = "IntegrationTest",
                Model = "IntegrationTest",
                Price = 100,
                Image = "IntegrationTest",
                MemoryCapacity = 8,
                MemoryType = "IntegrationTest",
                Length = 100,
                PowerConsumption = 100,
                Frequency = 1000,
                Technology = 10,
            };
            response = await client.PutAsync($"/api/v1/GPU/{gpuId}", new StringContent(JsonConvert.SerializeObject(gpu), Encoding.UTF8, "application/json"));
            result = await response.Content.ReadAsStringAsync();
            var gpuTest = JsonConvert.DeserializeObject<GetGPUDto>(result);

            Assert.AreEqual(gpu.Make, gpuTest.Make);
            Assert.AreEqual(gpu.Model, gpuTest.Model);
            Assert.AreEqual(gpu.Price, gpuTest.Price);
            Assert.AreEqual(gpu.Image, gpuTest.Image);
            Assert.AreEqual(gpu.Frequency, gpuTest.Frequency);
            Assert.AreEqual(gpu.MemoryCapacity, gpuTest.MemoryCapacity);
            Assert.AreEqual(gpu.Technology, gpuTest.Technology);
            Assert.AreEqual(gpu.MemoryType, gpuTest.MemoryType);
            Assert.AreEqual(gpu.PowerConsumption, gpuTest.PowerConsumption);
            Assert.AreEqual(gpu.Length, gpuTest.Length);
        }

        [TestMethod]
        public async Task Delete_GPU_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/GPU");
            var result = await response.Content.ReadAsStringAsync();
            var gpus = JsonConvert.DeserializeObject<List<GetGPUDto>>(result);
            var gpuId = gpus[0].GPUId;

            response = await client.DeleteAsync($"/api/v1/GPU/{gpuId}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task Delete_GPU_ShouldReturnNotFoundResponse()
        {
            var client = _factory.CreateClient();
            var gpuId = Guid.NewGuid();
            var response = await client.DeleteAsync($"/api/v1/GPU/{gpuId}");

            Assert.IsTrue(HttpStatusCode.NotFound == response.StatusCode);
        }

        private static void GPUAsserts(GetGPUDto gpu)
        {
            Assert.AreEqual("AMD", gpu.Make);
            Assert.AreEqual("RX7000XT", gpu.Model);
            Assert.AreEqual(1000.99, gpu.Price);
            Assert.AreEqual("none", gpu.Image);
            Assert.AreEqual(2000, gpu.Frequency);
            Assert.AreEqual(8, gpu.Technology);
            Assert.AreEqual("GDDR6", gpu.MemoryType);
            Assert.AreEqual(8, gpu.MemoryCapacity);
            Assert.AreEqual(300, gpu.PowerConsumption);
            Assert.AreEqual(250, gpu.Length);
        }
    }
}
