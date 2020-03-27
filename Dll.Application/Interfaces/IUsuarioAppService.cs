using Dll.Application.Model;
using Dll.Domain.DTO;
using Dll.Domain.Interfaces.Services;
using Dll.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Application.Interfaces
{
    public interface IUsuarioAppService 
    {
        UsuarioViewModel AdicionarAspNetUser(UsuarioViewModel user);
        UsuarioViewModelEdit AtualizarAspNetUser(UsuarioViewModelEdit user);
        List<UsuarioDTO> BuscarTodosUsuario();
        UsuarioViewModel BuscarPorEmail(string email);
        UsuarioViewModel BuscarPorNome(string nome);
        UsuarioViewModel BuscarPorId(int id);
        UsuarioViewModel BuscarPorCpf(string cpf);
        void Excluir(int id);
    }
}
