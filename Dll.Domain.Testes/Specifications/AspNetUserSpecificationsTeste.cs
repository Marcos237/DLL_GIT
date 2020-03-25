using Dll.Domain.Entity;
using Dll.Domain.Specification;
using Dll.Infra.CorssCutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dll.Domain.Testes.Specifications
{
    public class AspNetUserSpecificationsTeste
    {
        public AspNetUsers user { get; set; }

        [Fact(DisplayName = "User Specifications")]
        [Trait("Categoria", "Validar Email")]
        public void Email_Formato_Correto()
        {
            user = new AspNetUsers()
            {
                Email = "Teste2@test.com"
            };
            var email = new EmailValidoSpecifications();

            Assert.True(email.IsSatisfiedBy(user));
        }

        [Fact(DisplayName = "User Specifications")]
        [Trait("Categoria", "Validar Email")]
        public void Nome_Tamanho_Correto()
        {
            user = new AspNetUsers()
            {
                UserName = "122"
            };
            var nome = new NomeTamanhoCorretoSpecifications();

            Assert.True(nome.IsSatisfiedBy(user));
        }
    }
}
