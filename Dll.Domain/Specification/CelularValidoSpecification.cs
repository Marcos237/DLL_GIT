using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Specification
{
    class CelularValidoSpecification : ISpecification<Telefones>
    {
        public bool IsSatisfiedBy(Telefones entity)
        {
            return entity.ValidarTelefone(entity.Celular);
        }
    }
}