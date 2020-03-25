using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Specification
{
    public class NomeTamanhoCorretoSpecifications : ISpecification<AspNetUsers>
    {
        public bool IsSatisfiedBy(AspNetUsers entity)
        {
            return entity.UserName.Length > 2;
        }
    }
}
