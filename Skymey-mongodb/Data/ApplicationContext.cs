﻿using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using Skymey_main_lib.Models;

namespace Skymey_mongodb.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Exchanges> Exchanges { get; init; }
        public static ApplicationContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<ApplicationContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exchanges>().ToCollection("exchanges");
        }
    }
}
