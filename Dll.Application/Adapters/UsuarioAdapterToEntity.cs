using Dll.Application.Model;
using Dll.Domain.Entity;
using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Adapter
{
    public static class UsuarioAdapterToEntity
    {
        public static AspNetUsers ViewModelToEntity(UsuarioViewModel user)
        {
            var _user = new AspNetUsers()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };
            var Cpf = new CPF(user.CPF);
            var _usuario = new Usuario()
            {
                IdUser = user.Id,
                Cpf = Cpf
            };

            var id = Convert.ToInt32(user.Id);
            var _telefone = new Telefones(id, user.Telefone, user.Celular);

            _usuario.Telefones.Add(_telefone);
            _user.Usuario.Add(_usuario);

            return _user;

        }
    }
}
