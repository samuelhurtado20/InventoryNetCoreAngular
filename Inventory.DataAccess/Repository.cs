using Dapper.Contrib.Extensions;
using Inventory.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Inventory.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;

        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _connectionString = connectionString;
        }

        public bool Delete(T entity)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.GetAll<T>();
        }

        public T GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Get<T>(id);
        }

        public T Insert(T entity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Insert<T>(entity);
            return entity;
        }

        public bool Update(T entity)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Update<T>(entity);
        }
    }
}
