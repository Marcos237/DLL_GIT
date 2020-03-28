using Dll.Application.Adapter;
using Dll.Application.Adapters;
using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Interfaces.Services;
using Dll.Domain.ValueObjects;
using Dll.Infra.Data.Interface;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Application.Service
{
    public class UsuarioAppService : ApplicationService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioAppService(IUsuarioService usuarioService, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
            : base(unitOfWork)
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
            _signInManager = signInManager;
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
            model = UsuarioAdapterToViewModel.EntityToViewModel(query);
            if (result.Result.Succeeded && query.validateResult.IsValid)
            {
                query.validateResult.Success = "Cadastro realizado com sucesso!";
                model.ValidationResult.Info = "Registro Sucesso";
                Commit();
            }
            else
            {
                model.ValidationResult.Info = "Registrar Erro";
                var erros = result.Result.Errors;
                foreach (var item in erros)
                {
                    query.validateResult.notifications.Add(new Notification(1, item.Description, DateTime.Now));
                }
                _userManager.DeleteAsync(user);
            }
            return model;
        }

        public UsuarioViewModelEdit AtualizarAspNetUser(UsuarioViewModelEdit model)
        {
            var usuario = UsuarioEditAdapterToEntity.ViewModelEditToEntity(model);

            BeginTransaction();
            var query = _usuarioService.AtualizarAspNetUser(usuario);
            model = UsuarioEditAdapterToViwModel.EntityToViewModel(query);
            if (query.validateResult.IsValid)
            {
                Commit();
                query.validateResult.Success = "Cadastro atualizado com sucesso!";
                model.ValidationResult.Info = "Atualizar Sucesso";
            }
            else
            {
                model.ValidationResult.Info = "Atualizar Erro";
            }
            return model;
        }

        public UsuarioViewModel BuscarPorCpf(string cpf)
        {
            var dados = _usuarioService.BuscarTudoPorCpf(cpf);

            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            result.ValidationResult.Info = "BuscarPorCpf";
            return result;
        }

        public UsuarioViewModel BuscarPorEmail(string email)
        {
            var dados = _usuarioService.BuscarPorEmail(email);

            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);
            result.ValidationResult.Info = "BuscarPorEmail";
            return result;
        }

        public UsuarioViewModel BuscarPorId(int id)
        {
            var dados = _usuarioService.BuscarPorId(id);
            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            result.ValidationResult.Info = "BuscarPorId";
            return result;
        }

        public UsuarioViewModel BuscarPorNome(string nome)
        {
            var dados = _usuarioService.BuscarPorNome(nome);
            var result = UsuarioAdapterToViewModel.EntityToViewModel(dados);

            result.ValidationResult.Info = "BuscarPorNome";
            return result;
        }

        public List<UsuarioDTO> BuscarTodosUsuario()
        {

            var result = _usuarioService.BuscarTodosUsuario();

            foreach (var item in result)
            {
                item.ValidationResult.Info = "BuscarTodosUsuario";
            }
            return result;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
