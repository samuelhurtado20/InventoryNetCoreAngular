using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Business.Interfaces
{
    public interface IOrderBusiness
    {
        bool Delete(Order entity);
        bool Update(Order entity);
        Order Insert(Order entity);
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        IEnumerable<Order> PagedList(int page, int rows);
    }
}
