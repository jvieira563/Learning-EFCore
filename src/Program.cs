using EFCore.Console.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            HelthCheckBancoDeDados();
            //GapDoEnsureCreated();
            //EnsureCreatedAndDeleted();
        }

        static void ExecuteSQL()
        {
            using var db = new ApplicationContext();

            // Primeira opcao
            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT 1";
                cmd.ExecuteNonQuery();
            }

            // Segunda opcao
            var descricao = "teste";
            db.Database.ExecuteSqlRaw("UPDATE Departamentos SER Descricao = [0] WHERE Id = 1", descricao);
        }

        static void HelthCheckBancoDeDados()
        {
            using var db = new ApplicationContext();
            var canConnect = db.Database.CanConnect();

            if (canConnect) System.Console.WriteLine("Conexão realizada com o banco de dados...");
            else System.Console.WriteLine("Não foi possível realizar a conexão com o banco de dados...");
        }
        static void EnsureCreatedAndDeleted()
        {
            using var db = new ApplicationContext();
            //db.Database.EnsureCreated();
            db.Database.EnsureDeleted();
        }
        static void GapDoEnsureCreated()
        {
            using var db = new ApplicationContext();
            using var db1 = new ApplicationContextCidade();

            db.Database.EnsureCreated();
            db1.Database.EnsureCreated();

            var databaseCreator = db1.GetService<IRelationalDatabaseCreator>();

            databaseCreator.CreateTables();
        }
    }
}