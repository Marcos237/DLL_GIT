using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Interfaces
{
    public interface IUsuarioLogadoAppService
    {
        List<Log> BuscarTodosLog();
        Log BuscarPorDataLog(DateTime data);
        Log RegistrarLog(Log log);

    }
}
