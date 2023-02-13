using Microsoft.EntityFrameworkCore;
using WebSis.Models;

namespace WebSis.DataBase
{
    // Classe de contexto que armazena a string de conexão com banco de dados, o método que define a nomenclatura das tabelas e a instância das tabelas que serão usadas para acessar os registro dentro das tabelas.
    public class WebSisContext : DbContext
    {

        public WebSisContext()
        {
            // Construtor
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // O método OnConfiguring recebe por parâmetro um objeto de DbContextOptionsBuilder que será responsável por fazer a chamada do método UseMySql, para definir uma string de conexão.

            optionsBuilder.UseMySql("server=mysql8002.site4now.net;port=3306;database=db_a93358_dbsis;uid=a93358_dbsis;password=Ann@1170615;SslMode=Preferred;ConvertZeroDateTime=true;pooling=no");
        }

        //server=mysql8002.site4now.net;port=3306;database=db_a93358_dbsis;uid=a93358_dbsis;password=Ann@1170615;SslMode=Preferred;ConvertZeroDateTime=true;pooling=no

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // OnModelCreating recebe por parâmetro um objeto de ModelBuilder, que será utilizado para configurar os tipos das entidades passando os nomes das tabelas através da chamada de Entity<>.ToTable(); 

            modelBuilder.Entity<Users>().ToTable("Usuarios");
            modelBuilder.Entity<Secretaries>().ToTable("Secretarias");
            modelBuilder.Entity<TravelAuthorizations>().ToTable("Autorização de Viagem");

        }

        public DbSet<Users> Users { get; set; } // Instância da tabela de usuários responsável por atender as chamadas de acesso à tabela
        public DbSet<Secretaries> Secretaries { get; set; } // Instância da tabela de Secretarias responsável por atender as chamadas de acesso à tabela
        public DbSet<TravelAuthorizations> TravelAuthorizations { get; set; } // Instância da tabela de Autorização de Viagem responsável por atender as chamadas de acesso à tabela
    }
}