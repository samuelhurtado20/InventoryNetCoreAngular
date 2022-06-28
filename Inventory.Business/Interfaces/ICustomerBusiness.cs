using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        bool Delete(Customer entity);
        bool Update(Customer entity);
        Customer Insert(Customer entity);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        IEnumerable<Customer> PagedList(int page, int rows);
    }
}
