using AutoMapper;
using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Services;
using Dll.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Service
{
    public class UsuarioLogadoLogAppService : ApplicationService , IUsuarioLogadoAppService
    {
        private readonly IUsuarioLogadoLogService _usuariologado;
        private readonly IMapper _mapper;

        public UsuarioLogadoLogAppService(IUsuarioLogadoLogService usuarioLogado, IMapper mapper, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _usuariologado = usuarioLogado;
            _mapper = mapper;
        }
        public LogViewModel BuscarPorDataLog(DateTime data)
        {
            var result = _mapper.Map<LogViewModel>(_usuariologado.BuscarPorDataLog(data));
            return result;
        }

        public List<LogViewModel> BuscarTodosLog()
        {
            var result = _mapper.Map<List<LogViewModel>>(_usuariologado.BuscarTodosLog());
            return result;
        }

        public LogViewModel RegistrarLog(LogViewModel log)
        {
            var _log = _mapper.Map<Log>(log);
            _log.DataLog = DateTime.Now;
            var result = _mapper.Map<LogViewModel>(_usuariologado.RegistrarLog(_log));
            Commit();
            return result;

        }
    }
}