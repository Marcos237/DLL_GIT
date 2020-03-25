using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Excluir(int id);
        IEnumerable<TEntity> BuscarTodos();
        TEntity BUscarPorId(int id);
    }
}
