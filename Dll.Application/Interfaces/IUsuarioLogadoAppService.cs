using Dll.Application.Model;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Interfaces
{
    public interface IUsuarioLogadoAppService
    {
        List<LogViewModel> BuscarTodosLog();
        LogViewModel BuscarPorDataLog(DateTime data);
        LogViewModel RegistrarLog(LogViewModel log);

    }
}
