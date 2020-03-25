using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace Dll.Domain.Interfaces.Services
{
    public interface IUsuarioService : IDisposable
    {
        AspNetUsers AdicionarAspNetUser(AspNetUsers user);
        AspNetUsers AtualizarAspNetUser(AspNetUsers user);
        int BuscarUltimoUsuarioMaisUm();
        List<UsuarioDTO> BuscarTodosUsuario();
        AspNetUsers BuscarPorEmail(string email);
        AspNetUsers BuscarPorNome(string nome);
        AspNetUsers BuscarPorId(int id);
        Usuario BuscarPorCpf(string cpf);
        AspNetUsers BuscarTudoPorCpf(string cpf);
        void Excluir(int id);


    }
}
