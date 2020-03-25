using Dapper;
using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dll.Infra.Data.Repository
{
    public class TelefoneRepository : Repository<Telefones>, ITelefoneRepository
    {
        private DbConnection cn;
        public TelefoneRepository(UsuarioDbContext context)
            : base(context)
        {
            cn = _context.Database.GetDbConnection();
        }
        public Telefones AdicionarTelefone(Telefones obj)
        {
            return Adicionar(obj);
        }

        public Telefones AtualizarTelefone(Telefones obj)
        {
            return Atualizar(obj);
        }

        public UsuarioDTO BuscarTelefonePorIdUsuario(int id)
        {
            var sql = @"  SELECT A.ID, A.IDUSUARUIO, A.TELEFONE, A.CELULAR, B.CPF  FROM TELEFONES AS A
                          INNER JOIN USUARIO AS B ON A.IDUSUARUIO = B.ID WHERE A.ID = @SID";

            var result = cn.Query<UsuarioDTO>(sql, new { sid = id });

            return result.FirstOrDefault();
        }

        public IEnumerable<Telefones> BuscarTelefoneTodos()
        {
            return BuscarTodos();
        }

        public void Excluirtelefone(int id)
        {
            Excluir(id);
        }

        public Telefones BuscarTelefonePorId(int id)
        {
            return BUscarPorId(id);
        }
    }
}
