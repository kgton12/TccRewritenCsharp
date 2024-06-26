﻿using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Product.Delete;
using TccRewritenCsharp.Application.UseCases.Product.Get;
using TccRewritenCsharp.Application.UseCases.Product.GetId;
using TccRewritenCsharp.Application.UseCases.Product.Register;
using TccRewritenCsharp.Application.UseCases.Product.Update;
using TccRewritenCsharp.Communication.Requests.Product;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetProduct()
        {
            var useCase = new GetProductUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById([FromRoute] Guid id)
        {
            var useCase = new GetProductByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductById([FromRoute] Guid id, [FromBody] RequestProductJson request)
        {
            var useCase = new UpdateProductByIdUseCase();

            var response = await useCase.Execute(id, request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterProduct([FromBody] RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductById(Guid id)
        {
            var useCase = new DeleteProductByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}
