using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dll.Application.Model
{
    public class UsuarioViewModelEdit
    {

        [Key]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Nome")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Preencha o campo  email")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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
