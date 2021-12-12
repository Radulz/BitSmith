using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCPartsShop.Application.Commands.PSUCommands.RemovePSU;
using PCPartsShop.Application.Queries.PSUQueries.GetAllPSUs;
using PCPartsShop.Application.Queries.PSUQueries.GetPSUById;
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
    public class PSUControllerUnitTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllPSUsQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllPSUsQuery>(), It.IsAny<CancellationToken>())).Verifiable();

            //Act
            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAllPSUs();


            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllPSUsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetPSUByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetPSUByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            //Act
            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetPSUById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetPSUByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task RemovePSUCommandIsCalled()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<RemovePSUCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);
            await controller.RemovePSU(id);

            _mockMediator.Verify(x => x.Send(It.IsAny<RemovePSUCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetPSUById_ShouldReturnOkStatusCode()
        {
            var p = new PSU();
            _mockMediator
                .Setup(c => c.Send(It.IsAny<GetPSUByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(p);

            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetPSUById(p.ComponentId);
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task GetAllPSUs_ShouldReturnOkStatusCode()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllPSUsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<PSU>());

            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetAllPSUs();
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task RemovePSU_ShouldReturnNotFoundStatusCode()
        {
            bool result = false;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemovePSUCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemovePSU(id);
            var status = res as NotFoundObjectResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, status.StatusCode);
        }

        [TestMethod]
        public async Task RemovePSU_ShouldReturnNoContentStatusCode()
        {
            bool result = true;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemovePSUCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new PSUController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemovePSU(id);
            var status = res as NoContentResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, status.StatusCode);
        }
    }
}
