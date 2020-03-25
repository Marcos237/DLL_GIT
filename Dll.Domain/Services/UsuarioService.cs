using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Interfaces.Services;
using Dll.Domain.Validations;
using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dll.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUserRepository _user;
        private readonly IUsuarioRepository _usuario;
        private readonly ITelefoneRepository _telefone;

        public UsuarioService(IUserRepository user, IUsuarioRepository usuario, ITelefoneRepository telefone)
        {
            _user = user;
            _usuario = usuario;
            _telefone = telefone;
        }

        public AspNetUsers AdicionarAspNetUser(AspNetUsers user)
        {

            if (IsValid(user, "Gravar"))
            {
                foreach (var item in user.Usuario)
                {
                    _usuario.Adicionar(item);

                    foreach (var tel in item.Telefones)
                    {
                        _telefone.Adicionar(tel);
                    }
                }
                user.validateResult.Success = "Usuário cadastrado com sucesso :)";
            }

            return user;
        }

        public AspNetUsers AtualizarAspNetUser(AspNetUsers user)
        {
            var retorno = _user.BuscarUserPorId(Convert.ToInt32(user.Id));

            var userRetorno = new AspNetUsers()
            {
                Id = retorno.Id,
                UserName = user.UserName,
                NormalizedUserName = retorno.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = retorno.NormalizedEmail,
                EmailConfirmed = retorno.EmailConfirmed,
                PasswordHash = retorno.PasswordHash,
                SecurityStamp = retorno.SecurityStamp,
                ConcurrencyStamp = retorno.ConcurrencyStamp,
                PhoneNumber = retorno.PhoneNumber,
                PhoneNumberConfirmed = retorno.PhoneNumberConfirmed,
                TwoFactorEnabled = retorno.TwoFactorEnabled,
                LockoutEnd = retorno.LockoutEnd,
                LockoutEnabled = retorno.LockoutEnabled,
                AccessFailedCount = retorno.AccessFailedCount,
                validateResult = new ValidationResult(),
                Usuario = new List<Usuario>()
            };
            if (IsValid(userRetorno, "Atualizar"))
            {
                _user.AtualizarUsuario(userRetorno);

                var telRetorno = _telefone.BuscarTelefonePorIdUsuario(Convert.ToInt32(user.Id));
                userRetorno.Usuario.Add(new Usuario(user.Id, telRetorno.CPF));
                userRetorno.Usuario.FirstOrDefault().Telefones = new List<Telefones>();

                userRetorno.Usuario.FirstOrDefault().Telefones.Add(new Telefones(Convert.ToInt32(telRetorno.Id), telRetorno.Telefone, telRetorno.Celular));
                user.validateResult.Success = "Usuário atualizado com sucesso :)";
                return userRetorno;
            }
            else return user;
        }

        public Telefones AtualizarTelefone(int id)
        {
            var telRetorno = _telefone.BuscarTelefonePorId(id);
            _telefone.AtualizarTelefone(telRetorno);

            return telRetorno;
        }

        public Usuario BuscarPorCpf(string cpf)
        {
            var result = _usuario.BuscarPorCpf(cpf).Cpf;

            return null;
        }

        public AspNetUsers BuscarPorEmail(string email)
        {
            var result = _user.BuscarPorEmail(email);


            return result;
        }

        public AspNetUsers BuscarPorId(int id)
        {
            var result = _user.BuscarUsuarioPorId(id);

            return result;
        }

        public AspNetUsers BuscarPorNome(string nome)
        {
            var result = _user.BuscarPorNome(nome);

            return result;
        }

        public List<UsuarioDTO> BuscarTodosUsuario()
        {
            var user = _user.BuscarUsuarioTodos();
            var usuario = _usuario.BuscarUsuarioTodos();
            var telefone = _telefone.BuscarTelefoneTodos();

            var result = MontarUsuario(user, usuario, telefone).ToList();

            return result;

        }

        public List<UsuarioDTO> MontarUsuario(IEnumerable<AspNetUsers> user, IEnumerable<Usuario> usuario, IEnumerable<Telefones> telefone)
        {
            var result = (from u in user
                          join ur in usuario on u.Id equals ur.IdUser
                          join t in telefone on ur.Id equals t.IdUsuaruio
                          select new UsuarioDTO
                          {
                              Id = u.Id,
                              UserName = u.UserName,
                              Email = u.Email,
                              CPF = ur.Cpf.Codigo,
                              Telefone = t.Telefone,
                              Celular = t.Celular
                          }).ToList();

            return result;
        }

        public int BuscarUltimoUsuarioMaisUm()
        {
            var result = _user.BuscarUltimoIdMaisUm();

            return result;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
        public bool IsValid(AspNetUsers user, string tipo)
        {
            user.validateResult.IsValid = false;

            var usuarioResult = new UserCadastroValidator(_user, user);

            var result = ValidarNotificacoes(user.validateResult.notifications, user, tipo);

            var resultUser = user.validateResult.notifications.Count > 0;

            if (!resultUser)
            {
                user.validateResult.IsValid = true;
                return true;
            }
            else
                return false;
        }


        public List<Notification> ValidarNotificacoes(List<Notification> notifications, AspNetUsers user, string tipo)
        {
            var resultUsuario = false;
            var resultTeleFone = false;


            foreach (var item in user.Usuario)
            {
                if (tipo == "Gravar")
                {
                    var usuraioResult = new UsuarioCadastroValidator(_usuario, item);
                    resultUsuario = item.ValidationResult.notifications.Count > 0;
                    if (resultUsuario)
                        item.validateResult.BuscarMensagens(user.validateResult.notifications, item.ValidationResult.notifications);
                }
                foreach (var item2 in item.Telefones)
                {
                    var telefoneResult = new TelefoneCadastroValidator(item2);
                    resultTeleFone = item2.validateResult.notifications.Count > 0;

                    if (resultTeleFone)
                        item.validateResult.BuscarMensagens(user.validateResult.notifications, item.validateResult.notifications);

                }
            }

            return notifications;
        }
        public AspNetUsers BuscarTudoPorCpf(string cpf)
        {
            return _user.BuscarPorCPF(cpf);
        }

        public void Dispose()
        {
            _user.Dispose();
            _usuario.Dispose();
            _telefone.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
