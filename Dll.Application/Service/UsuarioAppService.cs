using Dll.Application.Adapter;
using Dll.Application.Adapters;
using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Interfaces.Services;
using Dll.Infra.Data.Interface;
using KissLog;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Application.Service
{
    public class UsuarioAppService : ApplicationService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;


        public UsuarioAppService(IUsuarioService usuarioService, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ILogger logger)
            : base(unitOfWork)
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public UsuarioViewModel AdicionarAspNetUser(UsuarioViewModel model)
        {
            model.Id = _usuarioService.BuscarUltimoUsuarioMaisUm().ToString();
            var usuario = UsuarioAdapterToEntity.ViewModelToEntity(model);
            BeginTransaction();
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            user.Id = model.Id;

            var result = _userManager.CreateAsync(user, model.Password);
            var query = _usuarioService.AdicionarAspNetUser(usuario);

            if (result.Result.Succeeded && query.validateResult.IsValid)
            {
                query.validateResult.Success = "Cadastro realizado com sucesso!";
                Commit();
            }
            else
            {
                var erros = result.Result.Errors;
                foreach (var item in erros)
                {
                    query.validateResult.notifications.Add(new Notification(1, item.Description, DateTime.Now));
                }
                _userManager.DeleteAsync(user);
            }
            model = UsuarioAdapterToViewModel.EntityToViewModel(query);

            return model;
        }

        public UsuarioViewModelEdit AtualizarAspNetUser(UsuarioViewModelEdit model)
        {
            var usuario = UsuarioEditAdapterToEntity.ViewModelEditToEntity(model);

            BeginTransaction();
            var query = _usuarioService.AtualizarAspNetUser(usuario);

            if (query.validateResult.IsValid)
            {
                Commit();
                query.validateResult.Success = "Cadastro atualizado com sucesso!";
            }
            model = UsuarioEditAdapterToViwModel.EntityToViewModel(query);
            return model;
        }

        public UsuarioViewModel BuscarPorCpf(string cpf)
        {
            var dados = _usuarioService.BuscarTudoPorCpf(cpf);

            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            return result;
        }

        public UsuarioViewModel BuscarPorEmail(string email)
        {
            var dados = _usuarioService.BuscarPorEmail(email);

            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            return result;
        }

        public UsuarioViewModel BuscarPorId(int id)
        {
            var dados = _usuarioService.BuscarPorId(id);
            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            return result;
        }

        public UsuarioViewModel BuscarPorNome(string nome)
        {
            var dados = _usuarioService.BuscarPorNome(nome);
            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            return result;
        }

        public List<UsuarioDTO> BuscarTodosUsuario()
        {
 
            var result =  _usuarioService.BuscarTodosUsuario();
            return result;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
