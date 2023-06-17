using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Application.Commands.FileUploadCommands;
using PCPartsShop.Application.Queries.FileQueries;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file == null)
            {
                return BadRequest();
            }

            var command = new FileUploadCommand { ImageFile = file };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("{blobName}")]
        public async Task<IActionResult> GetBlobByName(string blobName)
        {
            if(blobName == null)
            {
                return BadRequest();
            }

            var query = new GetBlobByNameQuery
            {
                BlobName = blobName
            };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
