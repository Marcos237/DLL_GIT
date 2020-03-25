using Dll.Domain.DTO;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface ITelefoneRepository : IRepository<Telefones>
    {
        Telefones AdicionarTelefone(Telefones obj);
        Telefones AtualizarTelefone(Telefones obj);
        void Excluirtelefone(int id);
        IEnumerable<Telefones> BuscarTelefoneTodos();
        Telefones BuscarTelefonePorId(int id);
        UsuarioDTO BuscarTelefonePorIdUsuario(int id);
    }
}
