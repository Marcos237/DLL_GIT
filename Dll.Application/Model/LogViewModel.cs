using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dll.Application.Model
{
    public class LogViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("UsuarioId")]
        public int UsuarioId { get;  set; }

        [DisplayName("DataLog")]
        public DateTime DataLog { get;  set; }

        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [DisplayName("IP")]
        public string IP { get; set; }

        [DisplayName("Navegador")]
        public string Navegador { get; set; }
    }
}
