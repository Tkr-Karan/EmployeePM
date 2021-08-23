using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Core.EmployeeManagement;
using EPM.Repository.EmployeeManagementRepo;
using Microsoft.AspNetCore.Mvc;

namespace EPM_UI.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _IEmployeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {
            _IEmployeeRepository = employeeRepository;
        }
        public IActionResult Index(int id)
        {

            if (id == 0)
                return View("~/Views/EmployeeForm/EmpForm.cshtml");
            else
            {
                var response = _IEmployeeRepository.GetEmployeeyID(id);
                return View("~/Views/EmployeeForm/EmpForm.cshtml", response);
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeUsers model)
        {
            if (model.Id == 0)
            {
                var response = await _IEmployeeRepository.CreateEmployee(model);

            }
            else
            {
                var response = await _IEmployeeRepository.UpadateEmployee(model);

            }
            return RedirectToAction("EmployeeDetails", "Employee");
        }


        public IActionResult EmployeeDetails()
        {
            var response = _IEmployeeRepository.GetEmployee();
            return View("~/Views/EmployeeForm/GetEmployee.cshtml", response);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response =await _IEmployeeRepository.DeleteEmployee(id);
            return Json(response);
        }

       
    }
}
