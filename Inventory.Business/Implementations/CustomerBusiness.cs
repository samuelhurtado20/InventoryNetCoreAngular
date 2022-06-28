using Inventory.Business.Interfaces;
using Inventory.Models;
using Inventory.UnitOfWork;
using System.Collections.Generic;

namespace Inventory.Business.Implementations
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly IUnitOfWork _uow;
        public CustomerBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Delete(Customer entity)
        {
            return _uow.Customer.Delete(entity);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _uow.Customer.GetAll();
        }

        public Customer GetById(int id)
        {
            return _uow.Customer.GetById(id);
        }

        public Customer Insert(Customer entity)
        {
            return _uow.Customer.Insert(entity);
        }

        public IEnumerable<Customer> PagedList(int page, int rows)
        {
            return _uow.Customer.GetCustomerPagedList(page, rows);
        }

        public bool Update(Customer entity)
        {
            return _uow.Customer.Update(entity);
        }
    }
}