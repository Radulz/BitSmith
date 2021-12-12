using AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCPartsShop.Application.Commands.CPUCommands.CreateCPU;
using PCPartsShop.Application.Commands.CPUCommands.RemoveCPU;
using PCPartsShop.Application.Queries.CPUQueries.GetAllCPUs;
using PCPartsShop.Application.Queries.CPUQueries.GetCPUById;
using PCPartsShop.Controllers;
using PCPartsShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop_WebAPI.Models;

namespace PCPartsShop.UnitTests
{
    [TestClass]
    public class CPUControllerUnitTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllCPUsQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllCPUsQuery>(), It.IsAny<CancellationToken>())).Verifiable();

            //Act
            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAllCPUs();


            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllCPUsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCPUByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetCPUByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            //Act
            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetCPUById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetCPUByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        //[TestMethod]
        //public async Task CreateCPUIsCalled()
        //{
        //    //Arrange
        //    _mockMediator.Setup(c => c.Send(It.IsAny<CreateCPUCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        //    CreateCPUDto cpu = new CreateCPUDto { Make = "Test", Model = "Test", Image = "Test", Frequency = 1.2, MemoryFrequency = 2666, NumberOfCores = 4, Price = 500, Socket = "Test", Technology = 7, ThermalDesignPower = 55 };

        //    //Act
        //    var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
        //    await controller.CreateCPU(cpu);

        //    _mockMediator.Verify(x => x.Send(It.IsAny<CreateCPUCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        //}

        [TestMethod]
        public async Task RemoveCPUCommandIsCalled()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveCPUCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
            await controller.RemoveCPU(id);

            _mockMediator.Verify(x => x.Send(It.IsAny<RemoveCPUCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCPUById_ShouldReturnOkStatusCode()
        {
            var cpu = new CPU
            {
                Make = "Test",
                Model = "Test",
                Image = "Test",
                Freq = 1.2,
                MFreq = 2666,
                Cores = 4,
                Price = 500,
                Socket = "Test",
                Tech = 7,
                TDP = 55
            };
            _mockMediator
                .Setup(c => c.Send(It.IsAny<GetCPUByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cpu);

            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetCPUById(cpu.ComponentId);
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task GetAllCPUs_ShouldReturnOkStatusCode()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllCPUsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<CPU>());

            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetAllCPUs();
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task RemoveCPU_ShouldReturnNotFoundStatusCode()
        {
            bool result = false;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveCPUCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveCPU(id);
            var status = res as NotFoundObjectResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, status.StatusCode);
        }

        [TestMethod]
        public async Task RemoveCPU_ShouldReturnNoContentStatusCode()
        {
            bool result = true;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveCPUCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new CPUController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveCPU(id);
            var status = res as NoContentResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, status.StatusCode);
        }
    }
}
