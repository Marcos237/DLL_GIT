using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Specification;
using System;

namespace Dll.Domain.Validations
{

    public class UserCadastroValidator
    {
        public UserCadastroValidator(IUserRepository user, AspNetUsers aspNetUsers)
        {
            var emailFormato = new EmailValidoSpecifications();
            var nomeTamanho = new NomeTamanhoCorretoSpecifications();


            if (!emailFormato.IsSatisfiedBy(aspNetUsers))
            {
                aspNetUsers.validateResult.notifications.Add(new Notification(1, "Email em formato incorreto.", DateTime.Now));
            }

            if (!nomeTamanho.IsSatisfiedBy(aspNetUsers))
            {
                aspNetUsers.validateResult.notifications.Add(new Notification(1, "O Login precisa ter ao menos 3 caracteres.", DateTime.Now));
            }
        }
    }
}
