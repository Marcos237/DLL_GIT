using Dll.Domain.DTO;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario AdicionarUsuario(Usuario obj);
        Usuario AtualizarUsuario(Usuario obj);
        void ExcluirUsuario(int id);
        IEnumerable<Usuario> BuscarUsuarioTodos();
        Usuario BuscarUsuarioPorId(int id);
        Usuario BuscarPorCpf(string cpf);
    }
}
