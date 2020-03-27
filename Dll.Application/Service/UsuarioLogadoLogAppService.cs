using Dll.Application.Interfaces;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Service
{
    public class UsuarioLogadoLogAppService : IUsuarioLogadoAppService
    {
        private readonly IUsuarioLogadoLogService _usuariologado;

        public UsuarioLogadoLogAppService(IUsuarioLogadoLogService usuarioLogado)
        {
            _usuariologado = usuarioLogado;
        }
        public Log BuscarPorDataLog(DateTime data)
        {
            var result = _usuariologado.BuscarPorDataLog(data);
            return result;
        }

        public List<Log> BuscarTodosLog()
        {
            var result = _usuariologado.BuscarTodosLog();
            return result;
        }

        public Log RegistrarLog(Log log)
        {
           var result = _usuariologado.RegistrarLog(log);
            return result;

        }
    }
}