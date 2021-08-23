using EPM.Core.UserManagement;
using EPM.Repository.UserManagementAuthenticate;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Implementation.UserManagementImplementation
{
    //import interface with class and define all methods ( EPM.Repository->UserManagementAuthenticate->Authenticate)
    public class AuthenticateImplementation : IAuthenticate
    {
        private readonly string _connectingString;

        public AuthenticateImplementation(IConfiguration configuration)
        {
            _connectingString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        public async Task<bool> CreateUser(AuthenticateUser Model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@UserName" , Model.UserName),
                new SqlParameter("@Password" , Model.Password)
            };

            var response =await Helper.Helper_DatabaseConnection.ExecuteNonQuery(_connectingString, Helper.Helper_DatabaseQuery.CreateUser, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> LoginUser(AuthenticateUser model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@UserName" , model.UserName),
                new SqlParameter("@Password" , model.Password)
            };

            var response = await Helper.Helper_DatabaseConnection.ExecuteScalar(_connectingString, Helper.Helper_DatabaseQuery.LoginUser, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        
        }
    }
}
