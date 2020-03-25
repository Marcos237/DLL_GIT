using Dapper;
using Dll.Domain.DTO;
using Dll.Domain.Entity;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Dll.Infra.Data.Repository
{
    public class AspNetUsersRepository : Repository<AspNetUsers>, IUserRepository
    {
        private DbConnection cn;


        public AspNetUsersRepository(UsuarioDbContext context)
            :base(context)
        {
            cn = _context.Database.GetDbConnection();
        }
        public AspNetUsers AdicionarUsuario(AspNetUsers obj)
        {
            return Adicionar(obj);
        }

        public AspNetUsers AtualizarUsuario(AspNetUsers obj)
        {
            return Atualizar(obj);
        }

        public AspNetUsers BuscarPorEmail(string email)
        {
            cn.Open();
            var sql = @"SELECT A.ID, A.USERNAME, A.EMAIL, U.CPF, T.CELULAR, T.TELEFONE  FROM ASPNETUSERS AS A
                       INNER JOIN USUARIO AS U  ON A.ID = U.IDUSER
                       INNER JOIN TELEFONES AS T ON U.ID = T.IDUSUARUIO
                       WHERE A.EMAIL = @SEMAIL  ";

            var result = cn.Query<AspNetUsers, UsuarioDTO, UsuarioDTO, AspNetUsers>(sql,
            (a, b, c) =>
            {
                a = new AspNetUsers(a.Id, a.UserName, a.Email);

                a.usuario = new Usuario(a.Id, b.CPF);
                a.telefone = new Telefones(Convert.ToInt32(a.Id), c.Telefone, c.Celular);

                a.Usuario = new List<Usuario>();
                a.Usuario.Add(a.usuario);
                a.usuario.Telefones = new List<Telefones>();
                a.usuario.Telefones.Add(a.telefone);

                return a;

            }, new { semail = email }, splitOn: "ID, CPF, CELULAR");

            cn.Close();
            return result.FirstOrDefault();

        }
        public AspNetUsers BuscarUsuarioPorId(int id)
        {
            var sql = @"SELECT A.ID, A.USERNAME, A.EMAIL, U.CPF, T.CELULAR, T.TELEFONE  FROM ASPNETUSERS AS A
                        INNER JOIN USUARIO AS U  ON A.ID = U.IDUSER
                        INNER JOIN TELEFONES AS T ON U.ID = T.IDUSUARUIO
                        WHERE A.ID = @SID";
            var result = cn.Query<AspNetUsers, UsuarioDTO, UsuarioDTO, AspNetUsers>(sql,
           (a, b, c) =>
           {
               a = new AspNetUsers(a.Id, a.UserName, a.Email);

               a.usuario = new Usuario(a.Id, b.CPF);
               a.telefone = new Telefones(Convert.ToInt32(a.Id), c.Telefone, c.Celular);

               a.Usuario = new List<Usuario>();
               a.Usuario.Add(a.usuario);
               a.usuario.Telefones = new List<Telefones>();
               a.usuario.Telefones.Add(a.telefone);

               return a;

           }, new { sid = id }, splitOn: "ID, CPF, CELULAR");

            return result.FirstOrDefault();
        }

        public AspNetUsers BuscarPorNome(string nome)
        {
            var sql = @"SELECT A.ID, A.USERNAME, A.EMAIL, U.CPF, T.CELULAR, T.TELEFONE  FROM ASPNETUSERS AS A
                       INNER JOIN USUARIO AS U  ON A.ID = U.IDUSER
                       INNER JOIN TELEFONES AS T ON U.ID = T.IDUSUARUIO
                       WHERE A.USERNAME = @SUSER";

            var result = cn.Query<AspNetUsers, UsuarioDTO, UsuarioDTO, AspNetUsers>(sql,
            (a, b, c) =>
            {
                a = new AspNetUsers(a.Id, a.UserName, a.Email);

                a.usuario = new Usuario(a.Id, b.CPF);
                a.telefone = new Telefones(Convert.ToInt32(a.Id), c.Telefone, c.Celular);

                a.Usuario = new List<Usuario>();
                a.Usuario.Add(a.usuario);
                a.usuario.Telefones = new List<Telefones>();
                a.usuario.Telefones.Add(a.telefone);

                return a;

            }, new { suser = nome }, splitOn: "ID, CPF, CELULAR");

            return result.FirstOrDefault();
        }

        public IEnumerable<AspNetUsers> BuscarUsuarioTodos()
        {
            var result = _context.AspNetUsers.ToList();

            return result;
        }

        public int BuscarUltimoIdMaisUm()
        {
            int i = 1;
            var result = _context.AspNetUsers.ToList();
            if (result.Count > 0)
            {
                var query = result.Max(c => Convert.ToInt32(c.Id) + 1);
                return query;
            }

            else
                return i;
        }

        public void ExcluirUsuario(int id)
        {
            Excluir(id);
        }

        public AspNetUsers BuscarPorCPF(string cpf)
        {
            var sql = @"SELECT A.ID, A.USERNAME, A.EMAIL, U.CPF, T.CELULAR, T.TELEFONE  FROM ASPNETUSERS AS A
                       INNER JOIN USUARIO AS U  ON A.ID = U.IDUSER
                       INNER JOIN TELEFONES AS T ON U.ID = T.IDUSUARUIO
                       WHERE U.CPF = @SCPF  ";

            var result = cn.Query<AspNetUsers, UsuarioDTO, UsuarioDTO, AspNetUsers>(sql,
        (a, b, c) =>
        {
            a = new AspNetUsers(a.Id, a.UserName, a.Email);

            a.usuario = new Usuario(a.Id, b.CPF);
            a.telefone = new Telefones(Convert.ToInt32(a.Id), c.Telefone, c.Celular);

            a.Usuario = new List<Usuario>();
            a.Usuario.Add(a.usuario);
            a.usuario.Telefones = new List<Telefones>();
            a.usuario.Telefones.Add(a.telefone);

            return a;

        }, new { scpf = cpf }, splitOn: "ID, CPF, CELULAR");

            return result.FirstOrDefault();
        }

        public AspNetUsers BuscarUserPorId(int id)
        {
            var sql = @"SELECT A.[ID]
                       ,A.[USERNAME]
                       ,A.[NORMALIZEDUSERNAME]
                       ,A.[EMAIL]
                       ,A.[NORMALIZEDEMAIL]
                       ,A.[EMAILCONFIRMED]
                       ,A.[PASSWORDHASH]
                       ,A.[SECURITYSTAMP]
                       ,A.[CONCURRENCYSTAMP]
                       ,A.[PHONENUMBER]
                       ,A.[PHONENUMBERCONFIRMED]
                       ,A.[TWOFACTORENABLED]
                       ,A.[LOCKOUTEND]
                       ,A.[LOCKOUTENABLED]
                       ,A.[ACCESSFAILEDCOUNT]
                        FROM [DLL_MM].[DBO].[ASPNETUSERS] AS A 
                        WHERE A.ID = @SID";
            var result = cn.Query<AspNetUsers>(sql, new { sid =  id });

            return result.FirstOrDefault();
        }
    }
}
