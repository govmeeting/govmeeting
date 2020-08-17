using System;
using System.Collections.Generic;
using System.Text;

using GM.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.Sqlite;


namespace GM.DatabaseAccess.Tests
{
    static class GetAppDbContext
    {

        static public ApplicationDbContext GetLocalDbProvider()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=GovmeetingTest;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        static public ApplicationDbContext GetInMemoryProvider()
        {
            InMemoryDatabaseRoot databaseRoot = new InMemoryDatabaseRoot();
            string connectionString = Guid.NewGuid().ToString();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(connectionString, databaseRoot);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        static public ApplicationDbContext GetInMemorySqliteProvider()
        {
            string connectionString = "DataSource=:memory:";
            SqliteConnection connection;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            connection = new SqliteConnection(connectionString);
            connection.Open();
            optionsBuilder.UseSqlite(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        static public ApplicationDbContext GetSqliteProvider()
        {
            string connectionString = $"DataSource={Guid.NewGuid()}.db";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(connectionString);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

    }
}
