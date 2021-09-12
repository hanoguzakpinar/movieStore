using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int customerID { get; set; }
        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _customer = _context.Customers.SingleOrDefault(x => x.Id == customerID);
            if (_customer is null)
                throw new InvalidOperationException("Customer bulunamadı.");

            var _order = _context.Orders.FirstOrDefault(x => x.CustomerID == customerID);
            if (_order is not null)
                throw new InvalidOperationException("Customer silinemez. Mevcut Siparişi Var.");

            _context.Customers.Remove(_customer);
            _context.SaveChanges();
        }
    }
}