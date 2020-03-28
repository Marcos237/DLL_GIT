using Dll.Application.Interfaces;
using Dll.Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Dll.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        private readonly IUsuarioLogadoAppService _log;
        private readonly ILoginAppService _login; 
        public LoginController(ILoginAppService login, IUsuarioLogadoAppService log)
            :base(log)
        {
            _log = log;
            _login = login;
        }
        [HttpPost]
        [Route("Login")]
        public bool RegistrarLog(LoginViewModel model)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                if (_login.Login(model))
                {
                    RegistrarLog(model);
                    result = true;
                }

                else
                {
                    RegistrarLog(model);
                    result = false;
                }

            }
            return result;
        }
    }
}