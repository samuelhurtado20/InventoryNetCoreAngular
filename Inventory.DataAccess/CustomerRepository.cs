using Dapper;
using Inventory.Models;
using Inventory.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Inventory.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base (connectionString)
        {

        }

        public IEnumerable<Customer> GetCustomerPagedList(int page, int rows)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@page", page);
                parameters.Add("@rows", rows);

                using var connection = new SqlConnection(_connectionString);
                return connection.Query<Customer>("dbo.CustomerPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
