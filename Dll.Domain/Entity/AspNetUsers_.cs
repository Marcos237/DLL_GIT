using Dll.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Dll.Domain.Entity
{
    public partial class AspNetUsers
    {
        public ValidationResult validateResult { get; set; }
        public Usuario usuario { get; set; }
        public Telefones telefone { get; set; }

        public AspNetUsers(string _id, string _nome, string _email)
        {
            Id = _id;
            UserName = _nome;
            Email = _email;
        }


        public bool ValidarEmail(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
