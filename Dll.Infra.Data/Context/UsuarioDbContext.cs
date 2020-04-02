using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Dll.Domain.Entity;
using Dll.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dll.Infra.Data
{
    public partial class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext()
            : base()
        {
        }

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Telefones> Telefones { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioDbContext).Assembly);

            foreach (var realtionship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys())) realtionship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }

    }

    public static class ChangeDb
    {
        public static void ChangeConnection(this UsuarioDbContext context, string con)
        {
            context.Database.GetDbConnection().ConnectionString = con;
        }   
    }
}
