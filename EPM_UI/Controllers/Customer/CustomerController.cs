using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Core.CustomerManagement;
using EPM.Repository.CustomerManagementRepo;
using Microsoft.AspNetCore.Mvc;

namespace EPM_UI.Controllers.Customer
{
    public class CustomerController : Controller
    {

        private readonly ICustomer _ICustomerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _ICustomerRepository = customerRepository;
        }

        public IActionResult Index(int id)
        {
            if (id == 0)
                return View("~/Views/CustomerForm/CustomerForm.cshtml");
            else
            {
                var response = _ICustomerRepository.GetCustomerID(id);
                return View("~/Views/CustomerForm/CustomerForm.cshtml", response);
            }

            // return View("~/Views/CustomerForm/CustomerForm.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerUsers model)
        {

            if (model.Id == 0)
            {
                var response = await _ICustomerRepository.CreateCustomer(model);

            }
            else
            {
                var response = await _ICustomerRepository.UpdateCustomer(model);

            }
            return RedirectToAction("CustomerDetails", "Customer");






            // var response = await _ICustomerRepository.CreateCustomer(model);
            //return Json(response);
        }


        public IActionResult CustomerDetails()
        {
            var response = _ICustomerRepository.GetCustomer();
            return View("~/Views/CustomerForm/GetCustomer.cshtml", response);
        }

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = await _ICustomerRepository.DeleteCustomer(id);
            return Json(response);
        }
    }
}
