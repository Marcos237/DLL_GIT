using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Validations;
using Dll.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dll.Domain.Testes.Validations
{
    public class UsuarioValidationTeste
    {
        public Usuario usuario { get; set; }

        [Fact(DisplayName = "Usuário está consistente para cadastro")]
        [Trait("Categoria", "Validar Usuario Cadastro")]
        public void Usuario_Apto_Cadastro()
        {
            usuario = new Usuario("23", "3566");
            var mock = new Mock<IUsuarioRepository>();
            mock.Setup(c => c.BuscarPorCpf(usuario.Cpf.Codigo)).Returns(usuario);

            var validate = new UsuarioCadastroValidator(mock.Object, usuario);
            Assert.True(usuario.ValidationResult.notifications.Count > 0);

        }
    }
}
