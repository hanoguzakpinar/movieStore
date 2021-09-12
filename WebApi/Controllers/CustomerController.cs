using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.Application.CustomerOperations.CreateCustomer;
using WebApi.Application.CustomerOperations.DeleteCustomer;
using WebApi.Application.CustomerOperations.GetOrders;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand cmd = new CreateTokenCommand(_context, _mapper, _configuration);
            cmd.Model = login;

            var token = cmd.Handle();

            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand cmd = new RefreshTokenCommand(_context, _configuration);
            cmd.RefreshToken = token;

            var resultToken = cmd.Handle();

            return resultToken;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand query = new DeleteCustomerCommand(_context);
            query.customerID = id;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrders(int id)
        {
            GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);
            query.customerID = id;

            GetOrdersQueryValidator validator = new GetOrdersQueryValidator();
            validator.ValidateAndThrow(query);

            var _orders = query.Handle();
            return Ok(_orders);
        }
    }
}