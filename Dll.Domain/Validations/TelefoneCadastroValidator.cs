using Dll.Domain.Entity;
using Dll.Domain.Specification;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dll.Domain.Validations
{
    public class TelefoneCadastroValidator
    {
        public TelefoneCadastroValidator(Telefones telefone)
        {
            var telefoneFormato = new TelefoneValidoSpecification();
            var celularFormato = new CelularValidoSpecification();

            if(!telefoneFormato.IsSatisfiedBy(telefone))
            {
                telefone.validateResult.notifications.Add(new Notification(1, "O Telefone deve ter entre 10 e 11 caracteres.", DateTime.Now));
            }

            if (!celularFormato.IsSatisfiedBy(telefone))
            {
                telefone.validateResult.notifications.Add(new Notification(1, "O Telefone deve ter entre 10 e 11 caracteres.", DateTime.Now));
            }
        }
    }
}
