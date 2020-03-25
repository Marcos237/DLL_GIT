using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Interfaces.Repository
{
    public interface ISpecification<TEntity> where  TEntity : class
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
