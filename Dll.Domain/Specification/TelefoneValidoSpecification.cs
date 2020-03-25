using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;

namespace Dll.Domain.Specification
{
    public class TelefoneValidoSpecification : ISpecification<Telefones>
    {
        public bool IsSatisfiedBy(Telefones entity)
        {
            return entity.ValidarTelefone(entity.Telefone);
        }
    }
}
