using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Log:Entity
    {
        public int UsuarioId { get;  set; }
        public DateTime DataLog { get;  set; }
        public string Descricao { get; set; }
        public string IP { get; set; }
        public string Navegador { get; set; }

        public Log()
        {
            DataLog = DateTime.Now;
        }
        public Log(int idusuarioLogado, string descricao, string ip, string maquina)
        {
            UsuarioId = idusuarioLogado;
            DataLog = DateTime.Now;
            Descricao = descricao;
            IP = ip;
            Navegador = maquina;
        }
    }
}
