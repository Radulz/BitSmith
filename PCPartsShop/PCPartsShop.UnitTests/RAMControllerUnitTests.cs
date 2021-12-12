using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PCPartsShop.Application.Commands.RAMCommands.RemoveRAM;
using PCPartsShop.Application.Queries.RAMQueries.GetAllRAMs;
using PCPartsShop.Application.Queries.RAMQueries.GetRAMById;
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
    public class RAMControllerUnitTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllRAMsQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllRAMsQuery>(), It.IsAny<CancellationToken>())).Verifiable();

            //Act
            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAllRAMs();


            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllRAMsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetRAMByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator.Setup(c => c.Send(It.IsAny<GetRAMByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            //Act
            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetRAMById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetRAMByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task RemoveRAMCommandIsCalled()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveRAMCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            Guid id = Guid.NewGuid();

            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);
            await controller.RemoveRAM(id);

            _mockMediator.Verify(x => x.Send(It.IsAny<RemoveRAMCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetRAMById_ShouldReturnOkStatusCode()
        {
            var r = new RAM();
            _mockMediator
                .Setup(c => c.Send(It.IsAny<GetRAMByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(r);

            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);

            var result = await controller.GetRAMById(r.ComponentId);
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task GetAllRAMs_ShouldReturnOkStatusCode()
        {
            _mockMediator.Setup(c => c.Send(It.IsAny<GetAllRAMsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<RAM>());

            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetAllRAMs();
            var statusCode = result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task RemoveRAM_ShouldReturnNotFoundStatusCode()
        {
            bool result = false;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveRAMCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveRAM(id);
            var status = res as NotFoundObjectResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, status.StatusCode);
        }

        [TestMethod]
        public async Task RemoveRAM_ShouldReturnNoContentStatusCode()
        {
            bool result = true;
            _mockMediator.Setup(c => c.Send(It.IsAny<RemoveRAMCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(result);
            Guid id = Guid.NewGuid();
            var controller = new RAMController(_mockMediator.Object, _mockMapper.Object);
            var res = await controller.RemoveRAM(id);
            var status = res as NoContentResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, status.StatusCode);
        }
    }
}
