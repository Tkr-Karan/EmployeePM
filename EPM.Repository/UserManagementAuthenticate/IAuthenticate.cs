using EPM.Core.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Repository.UserManagementAuthenticate
{
    public interface IAuthenticate
    {
        //it will create the user  
        Task<bool> CreateUser(AuthenticateUser Model); //user register (EPM.Core->UserManagement->Authenticate)
        Task<bool> LoginUser(AuthenticateUser model); //user login and authenticate
    }
}
