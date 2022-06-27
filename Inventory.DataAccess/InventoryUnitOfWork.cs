using Inventory.Repositories;
using Inventory.UnitOfWork;

namespace Inventory.DataAccess
{
    public class InventoryUnitOfWork : IUnitOfWork
    {
        public InventoryUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
        }

        public ICustomerRepository Customer { get; private set; }

        public IUserRepository User { get; private set; }

        public ISupplierRepository Supplier { get; private set; }
    }
}
