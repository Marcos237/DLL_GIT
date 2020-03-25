using KissLog;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Dll.Service.Extensions
{
    public class LogFilters : IActionFilter
    {
        private ILogger _logger;
        public LogFilters(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //if (context.HttpContext.User.Identity.IsAuthenticated)
            //{
                _logger.Debug(context.HttpContext.User.Identity.Name + "Acesso" +
                    context.HttpContext.Request.Method);

            //}
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
