using EPM.Core.UserManagement;
using EPM.Repository.UserManagementAuthenticate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EPM_UI.Controllers.Authenticate
{
    public class UserDetail : Controller
    {
        private readonly IAuthenticate _IAuthenticateRepository;

        public UserDetail(IAuthenticate authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterForm()
        {
            return View("~/Views/Forms/CreateUser.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(AuthenticateUser model)
        {
            var response = await _IAuthenticateRepository.CreateUser(model);
            return Json(response);
        }
    }
}
