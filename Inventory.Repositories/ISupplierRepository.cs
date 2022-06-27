using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetSupplierPagedList(int page, int rows);
    }
}
