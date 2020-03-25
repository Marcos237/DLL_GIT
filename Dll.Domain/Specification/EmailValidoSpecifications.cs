using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;

namespace Dll.Domain.Specification
{
    public class EmailValidoSpecifications : ISpecification<AspNetUsers>
    {
        public bool IsSatisfiedBy(AspNetUsers entity)
        {
            var result =  entity.ValidarEmail(entity.Email);

            return result;
        }
    }
}
