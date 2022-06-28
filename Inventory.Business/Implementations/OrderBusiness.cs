using Inventory.Business.Interfaces;
using Inventory.Models;
using Inventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Implementations
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IUnitOfWork _uow;
        public OrderBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Delete(Order entity)
        {
            return _uow.Order.Delete(entity);
        }

        public IEnumerable<Order> GetAll()
        {
            return _uow.Order.GetAll();
        }

        public Order GetById(int id)
        {
            return _uow.Order.GetById(id);
        }

        public Order Insert(Order entity)
        {
            return _uow.Order.Insert(entity);
        }

        public IEnumerable<Order> PagedList(int page, int rows)
        {
            return _uow.Order.GetOrderPagedList(page, rows);
        }

        public bool Update(Order entity)
        {
            return _uow.Order.Update(entity);
        }
    }
}
