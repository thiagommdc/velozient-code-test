using drone_delivery_service_api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Data;



namespace drone_delivery_service_api
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Drone> Drone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = GetProfiledConnection();
                optionsBuilder.UseSqlite(connection.ConnectionString);
            }
        }

        private DbConnection GetProfiledConnection()
        {
            var dbConnection = new SqlConnection("Data Source=app.db");
            return new StackExchange.Profiling.Data.ProfiledDbConnection(dbConnection, MiniProfiler.Current);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
