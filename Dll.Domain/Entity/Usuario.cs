using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Usuario : Entity
    {
        public string IdUser { get; set; }
        public CPF Cpf { get; set; }
        public string Imagem { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public virtual AspNetUsers IdUserNavigation { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Telefones> Telefones { get; set; }
        public virtual ICollection<Log> UsuarioLogado { get; set; }


        public Usuario()
        {
            Endereco = new HashSet<Endereco>();
            Telefones = new HashSet<Telefones>();
            UsuarioLogado = new HashSet<Log>();
            ValidationResult = new ValidationResult();
        }

        public Usuario(string idUser, string cpf)
        {
            IdUser = idUser;
            DefinirCPF(cpf);
            ValidationResult = new ValidationResult();
        }

        public void DefinirCPF(string cpf)
        {
            var meucpf = new CPF(cpf);
            Cpf = meucpf;
        }
    }
}
