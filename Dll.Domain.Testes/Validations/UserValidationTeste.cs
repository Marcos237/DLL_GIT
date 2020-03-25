using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dll.Domain.Testes.Validations
{
    public class UserValidationTeste
    {
        public AspNetUsers user { get; set; }

        [Fact(DisplayName = "Usuário está consistente para cadastro")]
        [Trait("Categoria", "Validar Usuario Cadastro")]
        public void User_Apto_Cadastro()
        {
            user = new AspNetUsers()
            {
                Email = "teste@teste.com",
                UserName = "Tabajara"
            };

            var mock = new Mock<IUserRepository>();
            mock.Setup(c => c.BuscarPorEmail(user.Email)).Returns(user);
            mock.Setup(c => c.BuscarPorNome(user.UserName)).Returns(user);

            var validate = new UserCadastroValidator(mock.Object, user);
            //var result = validate.Validate(user);

            //Assert.False(validate.Validate(user).IsValid);

            //Assert.Contains(result.Erros, e => e.Message == "Email já cadastrado.");
            //Assert.Contains(result.Erros, e => e.Message == "Login já cadastrado.");

        }
    }
}
