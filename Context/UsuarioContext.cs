using System;
using crud_csharp.Model;
using Microsoft.EntityFrameworkCore;

namespace crud_csharp.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        //sobrescrevendo a criação da tabela
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuario>();
         
            //alterando o nome da tabela
            usuario.ToTable("tb_usuario");

            //definindo a chave como o id
            usuario.HasKey(x => x.Id);

            //trocando o nome das tabelas
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }
    }
}