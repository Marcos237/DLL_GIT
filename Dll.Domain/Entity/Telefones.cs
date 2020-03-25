using Dll.Helpers;
using System;
using System.Collections.Generic;

namespace Dll.Domain.Entity
{
    public partial class Telefones : Entity
    {
        public int IdUsuaruio { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public virtual Usuario IdUsuaruioNavigation { get; set; }

        public Telefones(int id, string telefone, string celular)
        {
            IdUsuaruio = id;
            Telefone = telefone;
            Celular = celular;

        }
        public bool ValidarTelefone(string telefone)
        {
            var tel = TextoHelper.GetNumeros(telefone);

            if (tel.Length < 10 || tel.Length > 11)
                return false;
            else
                return true;
        }
    }
}
