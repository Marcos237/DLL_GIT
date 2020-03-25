using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Log:Entity
    {
        public int IdUsuarioLogado { get; private set; }
        public DateTime DataLog { get; private set; }
        public string Descricao { get; set; }

        public Log()
        {

        }
        public Log(int idusuarioLogado, string descricao)
        {
            IdUsuarioLogado = idusuarioLogado;
            DataLog = DateTime.Now;
            Descricao = descricao;
        }

        public virtual UsuarioLogado IdUsuaruioLogadoNavigation { get; set; }
    }
}
