using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Specification
{
    public class EmailUnicoSpecification : ISpecification<AspNetUsers>
    {
        private readonly IUserRepository _userRepository;

        public EmailUnicoSpecification(IUserRepository usuario)
        {
            _userRepository = usuario;
        }
        public bool IsSatisfiedBy(AspNetUsers entity)
        {
            var result = _userRepository.BuscarPorEmail(entity.Email) == null;
            return result;
        }
    }
}
