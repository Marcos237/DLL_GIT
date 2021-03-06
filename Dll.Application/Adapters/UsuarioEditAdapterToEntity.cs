﻿using Dll.Application.Model;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Adapters
{
    public static class UsuarioEditAdapterToEntity
    {   
        public static AspNetUsers ViewModelEditToEntity(UsuarioViewModelEdit user)
        {
            var _user = new AspNetUsers()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
            var _usuario = new Usuario()
            {
                IdUser = user.Id,
            };

            var id = Convert.ToInt32(user.Id);
            var _telefone = new Telefones(id, user.Telefone, user.Celular);

            _usuario.Telefones.Add(_telefone);
            _user.Usuario.Add(_usuario);

            return _user;
        }
    }
}
