using Dll.Application.Interfaces;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Services;
using Dll.Domain.ValueObjects;
using Dll.Infra.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Dll.Application.Service
{
    public class LogAppService : ApplicationService, ILog
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUsuarioLogadoLogService _usuarioLogado;

        public LogAppService(IHttpContextAccessor httpContextAccessor, 
            IUsuarioLogadoLogService usuarioLogado, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _usuarioLogado = usuarioLogado;
        }
        public void RegistrarLog(ValidationResult result, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var i = 1;
            var id = i;
            var ip = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            var maquina = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
            var mensagem = new StringBuilder();

            if (result.notifications.Count > 0 && signInManager.Context.User.Identity.IsAuthenticated)
            {
                mensagem.Append("Erro: ");
                foreach (var item in result.notifications)
                {
                    mensagem.Append(item.Menssagem + "; ");
                }
                var mensagemResult = mensagem.ToString().Remove(mensagem.Length - 2);
                _usuarioLogado.RegistrarLog(new Log(id, mensagemResult.ToString(), ip, maquina));
                Commit();
            }
            else if (signInManager.Context.User.Identity.IsAuthenticated)
            {
                _usuarioLogado.RegistrarLog(new Log(id, result.Info, ip, maquina));
                Commit();
            }

        }
    }
}