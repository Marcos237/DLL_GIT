using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Infra.Data.Repository
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(UsuarioDbContext context)
            :base(context)
        {

        }
        public Log RegistrarLog(Log log)
        {
            var result = Adicionar(log);

            return result;
        }
    }
}
