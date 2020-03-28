using Dll.Application.Interfaces;
using Dll.Application.Model;
using KissLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dll.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : Controller
    {
        private readonly IUsuarioLogadoAppService _log;
        private readonly ILogger _logger;
        public LogController(IUsuarioLogadoAppService log, ILogger logger)
        {
            _log = log;
            _logger = logger;
        }

        [HttpPost]
        [Route("RegistrarLog")]
        public LogViewModel RegistrarLog(LogViewModel model)
        {
            if(ModelState.IsValid)
            {
               model = _log.RegistrarLog(model);
            }
            return model;
        }

        [HttpGet]
        [Route("BuscarLogPorData")]
        public LogViewModel BuscarPorData(DateTime data)
        {
            var result = new LogViewModel();
            if (ModelState.IsValid)
            {

                result = _log.BuscarPorDataLog(data);
            }
            return result;
        }

        [HttpGet]
        [Route("BuscarTodosLog")]
        public List<LogViewModel> BuscarTodosLog()
        {
            var result = new List<LogViewModel>();
            if (ModelState.IsValid)
            {
                result = _log.BuscarTodosLog();
            }
            return result;
        }

    }
}