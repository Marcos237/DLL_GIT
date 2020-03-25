using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public int IdUsuaruio { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }

        public virtual Usuario IdUsuaruioNavigation { get; set; }
    }
}
