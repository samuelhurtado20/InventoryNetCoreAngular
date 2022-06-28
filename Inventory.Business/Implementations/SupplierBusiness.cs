using Inventory.Business.Interfaces;
using Inventory.Models;
using Inventory.UnitOfWork;
using System.Collections.Generic;

namespace Inventory.Business.Implementations
{
    public class SupplierBusiness : ISupplierBusiness
    {
        private readonly IUnitOfWork _uow;
        public SupplierBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Delete(Supplier entity)
        {
            return _uow.Supplier.Delete(entity);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _uow.Supplier.GetAll();
        }

        public Supplier GetById(int id)
        {
            return _uow.Supplier.GetById(id);
        }

        public Supplier Insert(Supplier entity)
        {
            return _uow.Supplier.Insert(entity);
        }

        public IEnumerable<Supplier> PagedList(int page, int rows)
        {
            return _uow.Supplier.GetSupplierPagedList(page, rows);
        }

        public bool Update(Supplier entity)
        {
            return _uow.Supplier.Update(entity);
        }
    }
}
