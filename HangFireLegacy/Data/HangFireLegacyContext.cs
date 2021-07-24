using System;
using System.Data.Entity;
using HangFireLegacy.Helpers;
using HangFireLegacy.Models;
using MySql.Data.EntityFramework;

namespace HangFireLegacy.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class HangFireLegacyContext : DbContext
    {

        public HangFireLegacyContext(string connectionString) : base(connectionString)
        {
            Database.Log = Logger.Info;
        }
        public HangFireLegacyContext():base("mysql") // connection string key
        {
            Database.Log = Console.Write;
        }
        public DbSet<Foo> Foos { get; set; }
    }
}
