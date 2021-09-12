using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderModel Model { get; set; }
        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _movie = _context.Movies.SingleOrDefault(x => x.Id == Model.MovieID);
            if (_movie is null)
                throw new InvalidOperationException("Movie mevcut değil.");
            var _customer = _context.Customers.SingleOrDefault(x => x.Id == Model.CustomerID);
            if (_customer is null)
                throw new InvalidOperationException("Customer mevcut değil.");

            var _order = _mapper.Map<Order>(Model);

            _context.Orders.Add(_order);
            _context.SaveChanges();
        }
    }
    public class CreateOrderModel
    {
        public DateTime OrderDate { get; set; }
        public int MovieID { get; set; }
        public int CustomerID { get; set; }
        public float Price { get; set; }
    }
}