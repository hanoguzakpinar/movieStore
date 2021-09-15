using System.Linq;
using WebApi.DBOperations;
using System;

namespace WebApi.Application.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        public UpdateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        public int customerID { get; set; }
        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var _customer = _context.Customers.SingleOrDefault(x => x.Id == customerID);
            if (_customer is null)
                throw new InvalidOperationException("Customer bulunamadı.");

            if (_context.Customers.Any(x => x.Email.ToLower() == Model.Email.ToLower() && x.Id != customerID))
                throw new InvalidOperationException("Email sistemde farklı customerda kayıtlı.");

            _customer.Name = _customer.Name != default ? _customer.Name = Model.Name : _customer.Name;
            _customer.Surname = _customer.Surname != default ? _customer.Surname = Model.Surname : _customer.Surname;
            _customer.Email = _customer.Email != default ? _customer.Email = Model.Email : _customer.Email;
            _customer.Password = _customer.Password != default ? _customer.Password = Model.Password : _customer.Password;

            _context.SaveChanges();
        }
    }

    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}