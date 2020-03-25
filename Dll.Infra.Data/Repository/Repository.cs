using Dll.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dll.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UsuarioDbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        protected IConfiguration _config;
        public Repository(UsuarioDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }
        public  TEntity Adicionar(TEntity obj)
        {
             DbSet.Add(obj);

            return obj;
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = _context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public TEntity BUscarPorId(int id)
        {
            var result = DbSet.Find(id.ToString());
            return result;
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return DbSet;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
