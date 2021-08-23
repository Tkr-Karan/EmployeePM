using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPM.Core.CustomerManagement
{
    public class CustomerUsers
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Customer Name is required..")]
        [MaxLength(100, ErrorMessage = "UserName length is too Long..")]
        [MinLength(6, ErrorMessage = "UserName length is too short..")]
        public string CustName { get; set; }

        [Required(ErrorMessage = "Customer Phone is required..")]
        public String Phone { get; set; }
        public string EmpCode { get; set; }

        [Required(ErrorMessage = "Customer Mail is required..")]
        public string Email { get; set; }
    }
}
