using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface IUsuarioLogadoRepository:IRepository<UsuarioLogado>,IDisposable
    {
        UsuarioLogado RegistrarUsuarioLogado(UsuarioLogado usuarioLogado);
        List<UsuarioLogado> BuscarTodosLog();
        UsuarioLogado BuscarPorDataLog(DateTime data);
    }
}
