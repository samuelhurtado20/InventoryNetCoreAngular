using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrderPagedList(int page, int rows);
    }
}
