using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.OrderOperations.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int orderID { get; set; }
        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _orders = _context.Orders.SingleOrDefault(x => x.Id == orderID);
            if (_orders is null)
                throw new InvalidOperationException("Order bulunamadı.");

            _context.Orders.Remove(_orders);
            _context.SaveChanges();
        }
    }
}