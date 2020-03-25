using Dll.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Dll.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private UsuarioDbContext _context;
        private bool _disposed;


        public UnitOfWork(UsuarioDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {

            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}