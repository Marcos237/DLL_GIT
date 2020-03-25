using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.ValueObjects;

namespace Dll.Domain.Specification
{
    public class CpfFormatoValidoSpecifications : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario entity)
        {
            var result = CPF.Validar(entity.Cpf.Codigo);

            return result;
        }
    }
}
