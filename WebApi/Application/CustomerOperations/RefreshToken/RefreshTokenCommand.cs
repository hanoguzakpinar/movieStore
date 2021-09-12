using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        readonly IConfiguration _configuration;
        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Valid bir Refresh Token Bulunamadı.");
            }
        }
    }
}