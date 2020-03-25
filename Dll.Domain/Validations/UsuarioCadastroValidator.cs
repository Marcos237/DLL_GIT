using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Specification;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Validations
{
    public class UsuarioCadastroValidator 
    {
        public UsuarioCadastroValidator(IUsuarioRepository usuario, Usuario user)
        {
            var cpfDuplicado = new CpfUnicoSpecifications(usuario);
            var cpfFormato = new CpfFormatoValidoSpecifications();
            var cpfTamanho = new CpfTamanhoCorretoSpecifications();

            if(!cpfDuplicado.IsSatisfiedBy(user))
            {
                user.ValidationResult.notifications.Add(new Notification(1, "CPF já cadastrado", DateTime.Now));
            }
            if(!cpfFormato.IsSatisfiedBy(user))
            {
                user.ValidationResult.notifications.Add(new Notification(1, "CPF com formato incorreto.", DateTime.Now));
            }
            if(!cpfTamanho.IsSatisfiedBy(user))
            {
                user.ValidationResult.notifications.Add(new Notification(1, "CPF copm formato incorreto", DateTime.Now));
            }

        }
    }
}
