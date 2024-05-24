﻿using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Product.GetId
{
    public class GetProductByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetProductByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public ResponseGetProductJson Execute(Guid id)
        {
            var validate = new Util();

            validate.Validate(id);

            var product = _dbContext.Product.Where(x => x.Id == id).Select(x => new ResponseGetProductJson
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                Category = x.Category
            }).FirstOrDefault();

            return product ?? throw new Exception("Product not found");
        }
    }
}
