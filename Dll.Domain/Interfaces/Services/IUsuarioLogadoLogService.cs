using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Services
{
    public interface IUsuarioLogadoLogService
    {
        UsuarioLogado RegistrarUsuarioLogado(UsuarioLogado usuarioLogado);
        List<UsuarioLogado> BuscarTodosLog();
        UsuarioLogado BuscarPorDataLog(DateTime data);
        Log RegistrarLog(Log log);
    }
}
