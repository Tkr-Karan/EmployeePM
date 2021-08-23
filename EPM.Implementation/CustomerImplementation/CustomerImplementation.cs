using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using EPM.Core.CustomerManagement;
using EPM.Repository.CustomerManagementRepo;
using Microsoft.Extensions.Configuration;

namespace EPM.Implementation.CustomerImplementation
{
    
    public class CustomerImplementation : ICustomer
    {
        private readonly string _connectingString;

        public CustomerImplementation(IConfiguration configuration)
        {
            _connectingString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }


        public async Task<bool> CreateCustomer(CustomerUsers model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@name", model.CustName),
                new SqlParameter("@phone", model.Phone),
                new SqlParameter("@email", model.Email),

            };
            var response = await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.CreateCutomer, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@id", Id)

            };
            var response = await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.DeleteCustomer, System.Data.CommandType.Text, parameter);


            return Convert.ToInt32(response) > 0;
        }

        public IEnumerable<CustomerUsers> GetCustomer()
        {
            var models = new List<CustomerUsers>();
            string commandText = @"get_Customers";
            using (SqlConnection con = new SqlConnection(_connectingString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new CustomerUsers();
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.CustName = reader["Name"].ToString();
                        model.Email = reader["Email"].ToString();
                        model.Phone = reader["Phone"].ToString();

                        models.Add(model);
                    }
                }
            }
            return models;
        }

        public CustomerUsers GetCustomerID(int Id)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@id", Id)

            };
            var model = new CustomerUsers();
            string selectCommand = @"Select Id, Name, Email, Phone from Employee where Id=@id";
            using (SqlConnection con = new SqlConnection(_connectingString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand(selectCommand, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.CustName = reader["Name"].ToString();
                        model.Email = reader["Email"].ToString();
                        model.Phone = reader["Phone"].ToString();
                    }
                }
                return model;
            }
        }

        public async Task<bool> UpdateCustomer(CustomerUsers model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@name", model.CustName),
                new SqlParameter("@email", model.Email),
                new SqlParameter("@phone", model.Phone),
                new SqlParameter("@id", model.Id),
            };

            var response = await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.UpdateCustomer, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }
    }
}
