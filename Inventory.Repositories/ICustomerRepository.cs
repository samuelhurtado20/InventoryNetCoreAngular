using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomerPagedList(int page, int rows);
    }
}
