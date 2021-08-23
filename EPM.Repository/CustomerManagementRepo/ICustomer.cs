using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EPM.Core.CustomerManagement;

namespace EPM.Repository.CustomerManagementRepo
{
    public interface ICustomer
    {
        Task<bool> CreateCustomer(CustomerUsers model);
        Task<bool> DeleteCustomer(int Id);
        Task<bool> UpdateCustomer(CustomerUsers model);
        IEnumerable<CustomerUsers> GetCustomer();
        CustomerUsers GetCustomerID(int Id);
    }
}
