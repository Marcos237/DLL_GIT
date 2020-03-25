using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Specification
{
    public class CpfUnicoSpecifications : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CpfUnicoSpecifications(IUsuarioRepository usuario)
        {
            _usuarioRepository = usuario;
        }

        public bool IsSatisfiedBy(Usuario entity)
        {
           var result =  _usuarioRepository.BuscarPorCpf(entity.Cpf.Codigo) == null;

            return result;
        }
    }
}
