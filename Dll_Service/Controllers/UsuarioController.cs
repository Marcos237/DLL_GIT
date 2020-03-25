using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.DTO;
using KissLog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dll.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuario;
        private readonly ILogger _logger;
        public UsuarioController(IUsuarioAppService usuario, ILogger logger)
        {
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
            }
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
            }
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
            }
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
            }
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
            }
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
            }
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
            return result;
        }
    }
}