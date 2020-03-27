using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Services
{
    public class UsuarioLogadoLogService : IUsuarioLogadoLogService
    {
        private readonly ILogRepository _log;

        public UsuarioLogadoLogService(ILogRepository log)
        {
            _log = log;
        }
        public Log BuscarPorDataLog(DateTime data)
        {
            var result = _log.BuscarPorDataLog(data);
            return result;
        }

        public List<Log> BuscarTodosLog()
        {
            var result = _log.BuscarTodosLog();
            return result;
        }

        public Log RegistrarLog(Log log)
        {
            var result = _log.RegistrarLog(log);
            return result;
        }
    }
}
