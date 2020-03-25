using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.DTO
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public int IdUsuaruio { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public Domain.ValueObjects.ValidationResult ValidationResult { get; set; }
    }
}
