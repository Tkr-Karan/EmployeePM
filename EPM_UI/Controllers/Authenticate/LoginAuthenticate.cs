using EPM.Core.UserManagement;
using EPM.Repository.UserManagementAuthenticate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM_UI.Controllers.Authenticate
{
    public class LoginAuthenticate : Controller
    {
        private readonly IAuthenticate _IAuthenticateRepository;

        public LoginAuthenticate(IAuthenticate authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginForm()
        {
            return View("~/Views/Forms/LoginUser.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUserAuthenticate(AuthenticateUser model)
        {
            var response = await _IAuthenticateRepository.LoginUser(model);
            if (response)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("LoginUserAuthenticate", "LoginAuthenticate");
        }
    }
}
