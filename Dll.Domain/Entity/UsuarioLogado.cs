using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class UsuarioLogado
    {
        public UsuarioLogado()
        {
            Log = new HashSet<Log>();
        }

        public int Id { get; set; }
        public int IdUsuaruio { get; set; }
        public string IP { get; set; }
        public string Maquina { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual Usuario IdUsuaruioNavigation { get; set; }
        public virtual ICollection<Log> Log { get; set; }
    }
}
