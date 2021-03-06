﻿using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Services
{
    public interface IUsuarioLogadoLogService
    {
        List<Log> BuscarTodosLog();
        Log BuscarPorDataLog(DateTime data);
        Log RegistrarLog(Log log);
    }
}
