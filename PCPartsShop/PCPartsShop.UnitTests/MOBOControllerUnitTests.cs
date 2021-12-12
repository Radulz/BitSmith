using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCPartsShop.Application.Commands.MOBOCommands.RemoveMOBO;
using PCPartsShop.Application.Queries.MOBOQueries.GetAllMOBOs;
using PCPartsShop.Application.Queries.MOBOQueries.GetMOBOById;
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
    public class MOBOControllerUnitTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllMOBOsQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllMOBOsQuery>(), It.IsAny<CancellationToken>())).Verifiable();

            //Act
            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAllMOBOs();


            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllMOBOsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetMOBOByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetMOBOByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            //Act
            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetMOBOById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetMOBOByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task RemoveMOBOCommandIsCalled()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveMOBOCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);
            await controller.RemoveMOBO(id);

            _mockMediator.Verify(x => x.Send(It.IsAny<RemoveMOBOCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetMOBOById_ShouldReturnOkStatusCode()
        {
            var mobo = new MOBO();
            _mockMediator
                .Setup(c => c.Send(It.IsAny<GetMOBOByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mobo);

            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetMOBOById(mobo.ComponentId);
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task GetAllMOBOs_ShouldReturnOkStatusCode()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllMOBOsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<MOBO>());

            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetAllMOBOs();
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task RemoveMOBO_ShouldReturnNotFoundStatusCode()
        {
            bool result = false;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveMOBOCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveMOBO(id);
            var status = res as NotFoundObjectResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, status.StatusCode);
        }

        [TestMethod]
        public async Task RemoveMOBO_ShouldReturnNoContentStatusCode()
        {
            bool result = true;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveMOBOCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new MOBOController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveMOBO(id);
            var status = res as NoContentResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, status.StatusCode);
        }
    }
}
