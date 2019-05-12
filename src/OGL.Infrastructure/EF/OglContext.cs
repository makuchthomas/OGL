using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OGL.Core.Domain;

namespace OGL.Infrastructure.EF
{
    public class OglContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }


        public OglContext(DbContextOptions<OglContext> options, SqlSettings sqlSettings) : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase(_sqlSettings.Database);
                return;
            }
            optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var itemBuilder = modelBuilder.Entity<User>();
            itemBuilder.HasKey(x => x.UserId);
        }
    }
}
