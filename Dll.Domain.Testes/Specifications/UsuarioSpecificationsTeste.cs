using Dll.Domain.Entity;
using Dll.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dll.Domain.Testes.Specifications
{
    public class UsuarioSpecificationsTeste
    {
        public Usuario usuario { get; set; }

        [Fact(DisplayName = "CPF Tamanho Válido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Tamanho_Correto()
        {
            usuario = new Usuario( "", "46643735033");
            var cpf = new CpfTamanhoCorretoSpecifications();

            Assert.True(cpf.IsSatisfiedBy(usuario));
        }

        [Fact(DisplayName = "CPF Formato Válido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Formato_Correto()
        {
            usuario = new Usuario("", "46643735033");
            var cpf = new CpfFormatoValidoSpecifications();

            Assert.True(cpf.IsSatisfiedBy(usuario));
        }
    }
}
