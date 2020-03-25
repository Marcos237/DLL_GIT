using Dll.Domain.DTO;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<AspNetUsers>
    {
        AspNetUsers AdicionarUsuario(AspNetUsers obj);
        AspNetUsers AtualizarUsuario(AspNetUsers obj);
        void ExcluirUsuario(int id);
        IEnumerable<AspNetUsers> BuscarUsuarioTodos();
        AspNetUsers BuscarUsuarioPorId(int id);
        int BuscarUltimoIdMaisUm();
        AspNetUsers BuscarPorNome(string nome);
        AspNetUsers BuscarPorEmail(string email);
        AspNetUsers BuscarPorCPF(string cpf);
        AspNetUsers BuscarUserPorId(int id);

    }
}
