using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCPartsShop.Application.Commands.GPUCommands.RemoveGPU;
using PCPartsShop.Application.Queries.GPUQueries.GetAllGPUs;
using PCPartsShop.Application.Queries.GPUQueries.GetGPUById;
using PCPartsShop.Controllers;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.UnitTests
{
    [TestClass]
    public class GPUControllerUnitTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllGPUsQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllGPUsQuery>(), It.IsAny<CancellationToken>())).Verifiable();

            //Act
            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAllGPUs();


            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllGPUsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetGPUByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetGPUByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            //Act
            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetGPUById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetGPUByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task RemoveGPUCommandIsCalled()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveGPUCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);
            await controller.RemoveGPU(id);

            _mockMediator.Verify(x => x.Send(It.IsAny<RemoveGPUCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetGPUById_ShouldReturnOkStatusCode()
        {
            var gpu = new GPU();
            _mockMediator
                .Setup(c => c.Send(It.IsAny<GetGPUByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(gpu);

            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetGPUById(gpu.ComponentId);
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task GetAllGPUs_ShouldReturnOkStatusCode()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllGPUsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<GPU>());

            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetAllGPUs();
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task RemoveGPU_ShouldReturnNotFoundStatusCode()
        {
            bool result = false;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveGPUCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveGPU(id);
            var status = res as NotFoundObjectResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, status.StatusCode);
        }

        [TestMethod]
        public async Task RemoveGPU_ShouldReturnNoContentStatusCode()
        {
            bool result = true;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveGPUCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new GPUController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveGPU(id);
            var status = res as NoContentResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, status.StatusCode);
        }
    }
}
