using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetOrdersModel> Handle()
        {
            var orderList = _context.Orders.Include(y => y.Movie).Include(z => z.Customer).OrderBy(xx => xx.Id).ToList<Order>();
            List<GetOrdersModel> oList = _mapper.Map<List<GetOrdersModel>>(orderList);
            return oList;
        }
    }
    public class GetOrdersModel
    {
        public string OrderDate { get; set; }
        public string Movie { get; set; }
        public string Customer { get; set; }
        public float Price { get; set; }
    }
}