using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EPM.Core.EmployeeManagement;

namespace EPM.Repository.EmployeeManagementRepo
{
    public interface IEmployee
    {
        Task<bool> CreateEmployee(EmployeeUsers model);
        Task<bool> DeleteEmployee(int Id);
        Task<bool> UpadateEmployee(EmployeeUsers model);
        IEnumerable<EmployeeUsers> GetEmployee();
        EmployeeUsers GetEmployeeyID(int Id);
       
    }
}
