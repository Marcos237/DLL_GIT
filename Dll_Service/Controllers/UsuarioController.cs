using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.DTO;
using KissLog;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Dll.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioLogadoAppService _log;
        private readonly IUsuarioAppService _usuario;
        private readonly ILogger _logger;
        public UsuarioController(IUsuarioAppService usuario, ILogger logger, IUsuarioLogadoAppService log, IHttpContextAccessor httpContextAccessor)
            :base(log, httpContextAccessor)
        {
            _log = log;
            _usuario = usuario;
            _logger = logger;
        }


        [HttpPost]
        [Route("Registrar")]
        public UsuarioViewModel SalvarUsuario(UsuarioViewModel model)
        {
            var result = new UsuarioViewModel();
            if (ModelState.IsValid)
            {
                result = _usuario.AdicionarAspNetUser(model);
                RegistrarLog(result.ValidationResult);
            }
            _logger.Info("Registrar");
            return result;
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public List<UsuarioDTO> BuscarTodosUsuario()
        {
            var result = new List<UsuarioDTO>();
            if (ModelState.IsValid)
            {
                result = _usuario.BuscarTodosUsuario();
                RegistrarLog(result.FirstOrDefault().ValidationResult);
            }
            _logger.Info("BuscarTodos");
            return result;
        }
        [HttpGet]
        [Route("BuscarPorId")]
        public UsuarioViewModel BuscarPoId(int id)
        {
            var result = new UsuarioViewModel();
            if (ModelState.IsValid)
            {
                result = _usuario.BuscarPorId(id);
                RegistrarLog(result.ValidationResult);
            }
            _logger.Info("BuscarPorId");
            return result;
        }
        [HttpGet]
        [Route("BuscarPorEmail")]
        public UsuarioViewModel BuscarPorEmail(string email)
        {
            var result = new UsuarioViewModel();
            if (ModelState.IsValid)
            {
                result = _usuario.BuscarPorEmail(email);
                RegistrarLog(result.ValidationResult);
            }
            _logger.Info("BuscarPorEmail");
            return result;
        }
        [HttpGet]
        [Route("BuscarPorCpf")]
        public UsuarioViewModel BuscarPorCpf(string cpf)
        {
            var result = new UsuarioViewModel();
            if (ModelState.IsValid)
            {
                result = _usuario.BuscarPorCpf(cpf);
                RegistrarLog(result.ValidationResult);
            }
            _logger.Info("BuscarPorCpf");
            return result;
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public UsuarioViewModel BuscarPorNome(string nome)
        {
            var result = new UsuarioViewModel();
            if (ModelState.IsValid)
            {
                result = _usuario.BuscarPorNome(nome);
                RegistrarLog(result.ValidationResult);
            }
            _logger.Info("BuscarPorNome");
            return result;
        }

        [HttpPut]
        [Route("Atualizar")]
        public UsuarioViewModelEdit AtualizarUsuario(UsuarioViewModelEdit model)
        {
            var result = new UsuarioViewModelEdit();
            if (ModelState.IsValid)
            {
                result = _usuario.AtualizarAspNetUser(model);
            }
            _logger.Info("Atualizar");
            return result;
        }
    }
}