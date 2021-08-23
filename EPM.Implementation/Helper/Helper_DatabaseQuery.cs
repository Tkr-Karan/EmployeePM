using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Implementation.Helper
{
    public class Helper_DatabaseQuery
    {
        //here we create the Authentication sql Query
        public static string CreateUser = @"insert into Authenticate (UserName , Password , CreatedBy) values (@userName , @password , 1)";

        public static string LoginUser = @"select count(1) from Authenticate where UserName=@UserName and Password=@Password and isActive=1 and isDeleted=0" ;


        //here we create the all Employee Sql Query
        public static string CreateEmployee = @"Insert into Employee (Name, Email, Phone, CreatedBy) Values(@name, @email, @phone, 1)";
        public static string DeleteEmployee = @"Delete from Employee where Id=@Id";
        public static string UpdateEmployee = @"Update Employee SET Name=@Name, Email=@Email, Phone=@Phone Where Id=@Id";
        public static string GetEmployee = @"Select Id, Name, Email, Phone from Customer where Id = @id";

        //here we create the all Customer Sql Query
        public static string CreateCutomer = @"Insert into Customer (Name, Email, Phone, CreatedBy) Values(@name, @email, @phone, 1)";
        public static string DeleteCustomer = @"Delete from Customer where Id=@Id";
        public static string UpdateCustomer = @"Update Customer SET Name=@Name, Email=@Email, Phone=@Phone Where Id=@Id";
        public static string GetCustomer = @"Select Id, Name, Email, Phone from Customer where Id = @id";

    }

}