using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface ILogRepository:IRepository<Log>
    {
        Log RegistrarLog(Log log);
    }

}
