using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Dll.Infra.Data.Repository
{
    public class UsuarioLogadoRepository : Repository<UsuarioLogado>, IUsuarioLogadoRepository
    {
        private  DbConnection cn;
        public UsuarioLogadoRepository(UsuarioDbContext context)
            :base(context)
        {
            cn = _context.Database.GetDbConnection();
        }
        public UsuarioLogado BuscarPorDataLog(DateTime data)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioLogado> BuscarTodosLog()
        {
            throw new NotImplementedException();
        }

        public UsuarioLogado RegistrarUsuarioLogado(UsuarioLogado usuarioLogado)
        {
            var result = Adicionar(usuarioLogado);
            return result;
        }
    }
}
