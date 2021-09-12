using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }

        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _dbContext;

        readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer is not null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddYears(5);

                _dbContext.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı - Şifre hatalı");
            }
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}