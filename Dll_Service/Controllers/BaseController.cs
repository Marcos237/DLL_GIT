using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.Entity;
using Dll.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dll.Service.Controllers
{
    public class BaseController : Controller
    {

        private readonly IUsuarioLogadoAppService _usuario;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IUsuarioLogadoAppService usuario, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _usuario = usuario;
        }
        public void RegistrarLog(ValidationResult result)
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var i = 1;
            var id = i;
            var ip = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            var maquina = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
            var mensagem = new StringBuilder();

            if (result.notifications.Count > 0 )
            {
                mensagem.Append("Erro: ");
                foreach (var item in result.notifications)
                {
                    mensagem.Append(item.Menssagem + "; ");
                }
                var mensagemResult = mensagem.ToString().Remove(mensagem.Length - 2);

                var log = new LogViewModel() { UsuarioId = id, Descricao = mensagemResult.ToString(), IP = ip, Navegador = maquina };
                _usuario.RegistrarLog(log);

            }
            else 
            {
                var log = new LogViewModel() { UsuarioId = id, Descricao = result.Info, IP = ip, Navegador = maquina };
                _usuario.RegistrarLog(log);
            }

        }
    }
}