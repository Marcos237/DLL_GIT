using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;

namespace Dll.Domain.Specification
{
    public class CpfTamanhoCorretoSpecifications : ISpecification<Usuario>
    {

        public bool IsSatisfiedBy(Usuario entity)
        {
            if (entity.Cpf.Codigo.Length == 11)
                return true;
            else
                return false;
        }
    }
}
