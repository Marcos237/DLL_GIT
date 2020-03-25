using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
    }
}
