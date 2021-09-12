using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int customerID { get; set; }
        public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetOrdersView> Handle()
        {
            var _orders = _context.Orders.Include(y => y.Movie).Include(z => z.Customer).Where(x => x.CustomerID == customerID).OrderBy(xx => xx.Id).ToList<Order>();
            List<GetOrdersView> oList = _mapper.Map<List<GetOrdersView>>(_orders);
            return oList;
        }
    }

    public class GetOrdersView
    {
        public DateTime OrderDate { get; set; }
        public string Movie { get; set; }
        public string Customer { get; set; }
        public float Price { get; set; }
    }
}