﻿using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Category.GetId
{
    public class GetCategoryrByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetCategoryrByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseCategoryJson> Execute(Guid id)
        {
            var category = await _dbContext.Category.Where(x => x.Id == id).Select(x => new ResponseCategoryJson
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return category ?? throw new Exception("Category not found");
        }
    }
}
