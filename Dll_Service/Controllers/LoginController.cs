using Dll.Application.Interfaces;
using Dll.Application.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dll.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        private readonly IUsuarioLogadoAppService _log;
        private readonly ILoginAppService _login; 
        public LoginController(ILoginAppService login, IUsuarioLogadoAppService log, IHttpContextAccessor httpContextAccessor)
            :base(log,  httpContextAccessor)
        {
            _log = log;
            _login = login;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<bool> RegistrarLogin(LoginViewModel model)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                result = await _login.Login(model);
                if (result)
                {
                    result = true;
                }

                else
                    result = false;
            }
            RegistrarLog(model.ValidationResult);

                return result;
        }
    }
}