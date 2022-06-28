using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Business.Interfaces
{
    public interface ISupplierBusiness
    {
        bool Delete(Supplier entity);
        bool Update(Supplier entity);
        Supplier Insert(Supplier entity);
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        IEnumerable<Supplier> PagedList(int page, int rows);
    }
}
