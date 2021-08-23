using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPM.Core.EmployeeManagement
{
    public class EmployeeUsers
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Employee Name is required..")]
        [MaxLength(100, ErrorMessage = "UserName length is too Long..")]
        [MinLength(6, ErrorMessage = "UserName length is too short..")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Employee Phone is required..")]
        public String Phone { get; set; }
        public string EmpCode { get; set; }

        [Required(ErrorMessage = "Employee Mail is required..")]
        public string Email { get; set; }
    }
}
