using Dapper;
using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Dll.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private DbConnection db;

        public UsuarioRepository(UsuarioDbContext context)
            : base(context)
        {
            db = _context.Database.GetDbConnection();
        }
        public Usuario AdicionarUsuario(Usuario obj)
        {
            return Adicionar(obj);
        }

        public Usuario AtualizarUsuario(Usuario obj)
        {
            return Atualizar(obj);
        }

        public Usuario BuscarPorCpf(string cpf)
        {
            var sql = @"SELECT ID, IDUSER, CPF FROM USUARIO WHERE CPF = @SCPF";
            var result = db.Query<Usuario, UsuarioDTO, Usuario>(sql, (a,b) =>
            {
                a = new Usuario(a.IdUser, b.CPF);
                return a;
            },
            new { scpf = cpf }, splitOn: "ID, IDUSER, CPF");
            return result.FirstOrDefault();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return BuscarUsuarioPorId(id);
        }

        public IEnumerable<Usuario> BuscarUsuarioTodos()
        {
            return BuscarTodos();
        }
        public void ExcluirUsuario(int id)
        {
            Excluir(id);
        }
    }
}
