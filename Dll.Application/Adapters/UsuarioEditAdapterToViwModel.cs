﻿using Dll.Application.Model;
using Dll.Domain.Entity;
using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Adapters
{
    public static class UsuarioEditAdapterToViwModel
    {
        public static UsuarioViewModelEdit EntityToViewModel(AspNetUsers entity)
        {
            if (entity != null)
            {
                var _user = new UsuarioViewModelEdit()
                {
                    Id = entity.Id,
                    UserName = entity.UserName,
                    Email = entity.Email,
                    ValidationResult = entity.validateResult
                };

                foreach (var item in entity.Usuario)
                {
                    _user.CPF = item.Cpf.Codigo;

                    foreach (var item2 in item.Telefones)
                    {
                        _user.Telefone = item2.Telefone;
                        _user.Celular = item2.Celular;

                    }
                }

                return _user;
            }
            else
            {
                var _user = new UsuarioViewModelEdit();
                _user.ValidationResult = new ValidationResult();
                _user.ValidationResult.Error = "A consulta não trouxe resultados.";
                return _user;
            }


        }
    }
}