﻿using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.Get
{
    public class GetUserUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetUserUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }
        public async Task<List<ResponseOrderUserJson>> Execute()
        {
            var user = await _dbContext.User.Select(x => new ResponseOrderUserJson
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Login = x.Login,
                PassWord = x.PassWord,
                Email = x.Email,
                Admin = x.Admin,
                Telephone = x.Telephone,
                Address = x.Address,
                City = x.City,
                State = x.State,
                Country = x.Country,
                ZipCode = x.ZipCode,
                Number = x.Number
            }).ToListAsync();

            return user ?? throw new Exception("User not found");
        }
    }
}
