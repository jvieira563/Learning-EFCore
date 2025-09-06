using System;
using EFCore.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.Console.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Host=localhost;Port=5432;Database=EFCore;Username=postgres;Password=1q2w!Q@W";

            optionsBuilder
                .UseNpgsql(connectionString)
                .EnableSensitiveDataLogging()
                .LogTo(System.Console.WriteLine, LogLevel.Information);
        }
    }
}
