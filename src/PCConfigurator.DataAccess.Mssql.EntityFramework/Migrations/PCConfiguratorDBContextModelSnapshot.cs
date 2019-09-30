﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCConfigurator.DataAccess.Mssql.EntityFramework;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Migrations
{
    [DbContext(typeof(PCConfiguratorDBContext))]
    partial class PCConfiguratorDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PCConfigurator.Core.Component", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ComponentTypeId")
                        .HasColumnName("component_type_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ComponentTypeId")
                        .IsUnique();

                    b.ToTable("components");

                    b.HasData(
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
                        });
                });

            modelBuilder.Entity("PCConfigurator.Core.ComponentType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("component_types");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Motherboard"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "CPU"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "GPU"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "RAM"
                        });
                });

            modelBuilder.Entity("PCConfigurator.Core.Configuration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("configurations");
                });

            modelBuilder.Entity("PCConfigurator.Core.ConfigurationComponent", b =>
                {
                    b.Property<long>("ComponentId")
                        .HasColumnName("component_id")
                        .HasColumnType("bigint");

                    b.Property<long>("ConfigurationId")
                        .HasColumnName("configuration_id")
                        .HasColumnType("bigint");

                    b.HasKey("ComponentId", "ConfigurationId");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("configurations_components");
                });

            modelBuilder.Entity("PCConfigurator.Core.Component", b =>
                {
                    b.HasOne("PCConfigurator.Core.ComponentType", "ComponentType")
                        .WithOne()
                        .HasForeignKey("PCConfigurator.Core.Component", "ComponentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PCConfigurator.Core.ConfigurationComponent", b =>
                {
                    b.HasOne("PCConfigurator.Core.Component", "Component")
                        .WithMany()
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCConfigurator.Core.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
