using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using EPM.Core.EmployeeManagement;
using EPM.Repository.EmployeeManagementRepo;
using Microsoft.Extensions.Configuration;

namespace EPM.Implementation.EmployeeImplementation
{
    public class EmployeeImplementation : IEmployee
    {
        private readonly string _connectingString;

        public EmployeeImplementation(IConfiguration configuration)
        {
            _connectingString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        public async Task<bool> CreateEmployee(EmployeeUsers Model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@name", Model.EmpName),
                new SqlParameter("@phone", Model.Phone),
                new SqlParameter("@email", Model.Email),

            };
            var response = await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.CreateEmployee, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@id", Id)

            };
            var response = await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.DeleteEmployee, System.Data.CommandType.Text, parameter);
            

            return Convert.ToInt32(response) > 0;
        }

        public IEnumerable<EmployeeUsers> GetEmployee()
        {
            var models = new List<EmployeeUsers>();
            string commandText = @"get_Employees";
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
                        var model = new EmployeeUsers();
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.EmpName = reader["Name"].ToString();
                        model.Email = reader["Email"].ToString();
                        model.Phone = reader["Phone"].ToString();

                        models.Add(model);
                    }
                }
            }
            return models;
        }

        public EmployeeUsers GetEmployeeyID(int Id)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@id", Id)

            };
            var model = new EmployeeUsers();
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
                        model.EmpName = reader["Name"].ToString();
                        model.Email = reader["Email"].ToString();
                        model.Phone = reader["Phone"].ToString();
                    }
                }
                return model;
            }
        }

        public async Task<bool> UpadateEmployee(EmployeeUsers model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@name", model.EmpName),
                new SqlParameter("@email", model.Email),
                new SqlParameter("@phone", model.Phone),
                new SqlParameter("@id", model.Id),
            };

            var response = await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.UpdateEmployee,System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }
    }

}
