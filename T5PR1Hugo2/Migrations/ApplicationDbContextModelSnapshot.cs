﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using T5PPR1Hugo2.Data;

#nullable disable

namespace T5PR1Hugo2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("T5PPR1Hugo2.Model.Simulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CabalAigua")
                        .HasColumnType("float");

                    b.Property<double>("CostKWh")
                        .HasColumnType("float");

                    b.Property<string>("DataHora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EnergiaGenerada")
                        .HasColumnType("float");

                    b.Property<double>("HoresSol")
                        .HasColumnType("float");

                    b.Property<double>("PreuKWh")
                        .HasColumnType("float");

                    b.Property<double>("Rati")
                        .HasColumnType("float");

                    b.Property<string>("Tipus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("VelocitatVent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Simulations");
                });

            modelBuilder.Entity("T5PR1Hugo2.Model.Consum", b =>
                {
                    b.Property<int>("CodiComarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodiComarca"));

                    b.Property<double>("ActivitatsEconomiques")
                        .HasColumnType("float");

                    b.Property<int>("Any")
                        .HasColumnType("int");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ConsumDomesticPerCapita")
                        .HasColumnType("float");

                    b.Property<double>("DomesticXarxa")
                        .HasColumnType("float");

                    b.Property<string>("Poblacio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("CodiComarca");

                    b.ToTable("Consums");
                });
#pragma warning restore 612, 618
        }
    }
}
