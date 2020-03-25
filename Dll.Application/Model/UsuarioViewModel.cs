using Dll.Domain.Entity;
using Dll.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dll.Application.Model
{
    public class UsuarioViewModel
    {
        [Key]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Nome")]
        public string UserName { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não é igual.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Preencha o campo  email")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo  Celular")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [DisplayName("Telefone")]
        [MaxLength(11)]
        public string Telefone { get; set; }

        [ScaffoldColumn(false)]
        public Domain.ValueObjects.ValidationResult ValidationResult { get; set; }
    }
}
