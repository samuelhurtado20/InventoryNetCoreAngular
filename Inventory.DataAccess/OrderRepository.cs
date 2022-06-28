using Dapper;
using Inventory.Models;
using Inventory.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Inventory.DataAccess
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<Order> GetOrderPagedList(int page, int rows)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@page", page);
                parameters.Add("@rows", rows);

                using var connection = new SqlConnection(_connectionString);
                return connection.Query<Order>("dbo.OrderPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
