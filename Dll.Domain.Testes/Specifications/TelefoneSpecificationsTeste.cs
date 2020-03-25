using Dll.Domain.Entity;
using Dll.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dll.Domain.Testes.Specifications
{
    public class TelefoneSpecificationsTeste
    {
        public Telefones telefone { get; set; }

        [Fact(DisplayName = "Telefone Formato Válido Specifications")]
        [Trait("Categoria", "Validar Telefone")]
        public void Telefone_Formato_Correto()
        {
            telefone = new Telefones(1,"1156775967", "976337887");
            var tel = new TelefoneValidoSpecification();

            Assert.True(tel.IsSatisfiedBy(telefone));
        }
    }
}
