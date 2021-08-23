using EPM.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPM.Core.UserManagement
{
    public class AuthenticateUser:BaseModel<int>
    {
        [Required(ErrorMessage ="UserName is required..")]
        [MinLength(6 , ErrorMessage ="UserName length is too short..")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required..")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required..")]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage ="Password is not match..")]
        public string ConfirmPassword { get; set; }

    }
}
