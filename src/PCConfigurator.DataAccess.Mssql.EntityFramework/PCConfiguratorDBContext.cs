﻿namespace PCConfigurator.DataAccess.Mssql.EntityFramework
{
    using PCConfigurator.Core;

    using Microsoft.EntityFrameworkCore;

    public class PCConfiguratorDBContext : DbContext
    {
        public PCConfiguratorDBContext(DbContextOptions<PCConfiguratorDBContext> options)
            : base(options)
        { }

        public DbSet<ComponentType> ComponentTypes { get; set; }
        
        public DbSet<T> GetSet<T>() where T : class
        {
            return this.GetSet<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddComponentType(modelBuilder);
            AddComponent(modelBuilder);
            AddConfiguration(modelBuilder);
            SeedData(modelBuilder);
        }

        private void AddComponentType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentType>().ToTable("component_types");
            modelBuilder.Entity<ComponentType>()
                .Property(t => t.Id).HasColumnName("id").UseIdentityColumn();
            modelBuilder.Entity<ComponentType>()
                .Property(t => t.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<ComponentType>()
                .HasKey(t => t.Id);            
        }

        private void AddComponent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>().ToTable("components");
            modelBuilder.Entity<Component>()
                .Property(t => t.Id).HasColumnName("id").UseIdentityColumn();
            modelBuilder.Entity<Component>()
                .Property(t => t.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Component>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Component>().Property(x => x.ComponentTypeId).HasColumnName("component_type_id");
            modelBuilder.Entity<Component>()
               .HasOne(c => c.ComponentType)
               .WithMany(c => c.Components)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Component>()
                .Property(t => t.Price).HasColumnName("price").IsRequired();            
        }

        private void AddConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>().ToTable("configurations");

            modelBuilder.Entity<Configuration>().Property(t => t.Id).HasColumnName("id").UseIdentityColumn();
            modelBuilder.Entity<Configuration>().HasKey(t => t.Id);

            modelBuilder.Entity<Configuration>().Property(t => t.Name).HasColumnName("name").IsRequired();

            modelBuilder.Entity<ConfigurationComponent>().ToTable("configurations_components");
            modelBuilder.Entity<ConfigurationComponent>().Property(t => t.ComponentId).HasColumnName("component_id");
            modelBuilder.Entity<ConfigurationComponent>().Property(t => t.ConfigurationId).HasColumnName("configuration_id");
            modelBuilder.Entity<ConfigurationComponent>().Property(t => t.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<ConfigurationComponent>().HasKey(
                    cc => new { component_id = cc.ComponentId, configuration_id = cc.ConfigurationId });
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentType>().HasData(
                    new ComponentType(1, "Motherboard"),
                    new ComponentType(2, "CPU"),
                    new ComponentType(3, "GPU"),
                    new ComponentType(4, "RAM")
                );

            modelBuilder.Entity<Component>().HasData(
                    new
                    {
                        Id = 1L,
                        ComponentTypeId = 1L,
                        Name = "MSI Z390-A PRO",
                        Price = 200m
                    },
                    new
                    {
                        Id = 2L,
                        ComponentTypeId = 2L,
                        Name = "AMD FX-8150",
                        Price = 150m
                    },
                    new
                    {
                        Id = 3L,
                        ComponentTypeId = 2L,
                        Name = "Intel i5-6500T",
                        Price = 180m
                    },
                    new
                    {
                        Id = 4L,
                        ComponentTypeId = 3L,
                        Name = "GTX 960",
                        Price = 230m
                    },
                    new
                    {
                        Id = 5L,
                        ComponentTypeId = 4L,
                        Name = "Corsair Vengeance LED 16Gb (2x8GB) DDR4 3000MHz",
                        Price = 230m
                    }
                );
        }
    }
}
