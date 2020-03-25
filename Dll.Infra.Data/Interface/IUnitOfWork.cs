using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Infra.Data.Interface
{
    public interface IUnitOfWork 
    {
        void BeginTransaction();
        void Commit();
    }
}
