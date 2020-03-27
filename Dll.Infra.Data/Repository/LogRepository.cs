using Dapper;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Dll.Infra.Data.Repository
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        private DbConnection cn;
        public LogRepository(UsuarioDbContext context)
            :base(context)
        {
            cn = _context.Database.GetDbConnection();
        }
        public Log BuscarPorDataLog(DateTime data)
        {
            var sql = @"SELECT A.ID,A.IDUSUARUIO, A.IP, A.MAQUINA, A.DATAINCLUSAO, A.DESCRICAO, A.DATALOG FROM USUARIOLOGADO AS A
                        WHERE B.DATALOG = @SDATA";
            var result = cn.Query<Log>(sql, new { sdata = data }).FirstOrDefault();

            return result;
        }

        public List<Log> BuscarTodosLog()
        {
            var sql = @"SELECT A.ID,A.IDUSUARUIO, A.IP, A.MAQUINA, A.DATAINCLUSAO, A.DESCRICAO, A.DATALOG FROM USUARIOLOGADO AS A";
            var result = cn.Query<Log>(sql).ToList();
            return result;
        }
        public Log RegistrarLog(Log log)
        {
            var result = Adicionar(log);

            return result;
        }
    }
}
