using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Features.Commands.DeleteProduct;
using ProductApp.Application.Features.Commands.UpdateProduct;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid product data.");
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id };
            return Ok(await _mediator.Send(query));

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid product data.");
            }

            command.Id = id;

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            var response = await _mediator.Send(command);

            if (response.Value)
                return Ok("Product deleted successfully.");
            else
                return NotFound("Product not found.");
        }

    }
}

