using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Specification
{
    public class NomeUnicoSpecification : ISpecification<AspNetUsers>
    {
        private readonly IUserRepository _user;

        public NomeUnicoSpecification(IUserRepository user)
        {
            _user = user;
        }
        public bool IsSatisfiedBy(AspNetUsers entity)
        {
            var result = _user.BuscarPorNome(entity.UserName) == null;
            return result;
        }
    }
}
