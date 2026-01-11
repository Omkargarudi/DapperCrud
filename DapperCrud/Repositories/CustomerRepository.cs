using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using DapperCrud.Models;
using Dapper;

namespace DapperCrud.Repositories
{
    public class CustomerRepository
    {
        private readonly String constr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        // Read all customer
        public List<Customer> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            { 
                return conn.Query<Customer>("Select * from Customers").ToList();
            }   
        }

        // Reasd by id
        public Customer GetById(int id)
        {
            using(SqlConnection conn = new SqlConnection(constr))
            {
                return conn.QuerySingleOrDefault<Customer>("Select * from Customers Where CustomerId =@id", new { Id = id });
            }
        }

        // Create Customer
        public void Insert(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sql = @"INSERT INTO Customers (Name, Mobile, Balance)
                           VALUES (@Name, @Mobile, @Balance)";
                conn.Execute(sql, customer);
            }
        }

        // UPDATE
        public void Update(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            { 
                string sql = @"UPDATE Customers
                           SET Name=@Name, Mobile=@Mobile, Balance=@Balance
                           WHERE CustomerId=@CustomerId";
                conn.Execute(sql, customer);
            }
        }

        // DELETE
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Execute("DELETE FROM Customers WHERE CustomerId=@Id",
                            new { Id = id });
            }
        }
    }
}