using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Log:Entity
    {
        public int UsuarioId { get; private set; }
        public DateTime DataLog { get; private set; }
        public string Descricao { get; set; }
        public string IP { get; set; }
        public string Navegador { get; set; }

        public Log()
        {

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
