using System.Collections.Generic;

namespace Inventory.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Delete(T entity);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetAll();
        T GetNyId(int id);
    }
}
