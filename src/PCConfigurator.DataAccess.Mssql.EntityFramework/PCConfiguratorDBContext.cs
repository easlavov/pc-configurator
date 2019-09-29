namespace PCConfigurator.DataAccess.Mssql.EntityFramework
{
    using System;

    using PCConfigurator.Core;

    using Microsoft.EntityFrameworkCore;

    public class PCConfiguratorDBContext : DbContext
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=PCConfigurator;Trusted_Connection=True;";

        public DbSet<ComponentType> ComponentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentType>().ToTable("component_types");
            modelBuilder.Entity<ComponentType>()
                .Property(t => t.Id).HasColumnName("id").UseIdentityColumn();
            modelBuilder.Entity<ComponentType>()
                .Property(t => t.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<ComponentType>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<ComponentType>().HasData(
                    new ComponentType(1, "Motherboard"),
                    new ComponentType(2, "CPU"),
                    new ComponentType(3, "GPU"),
                    new ComponentType(4, "RAM")
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);

    }
}
