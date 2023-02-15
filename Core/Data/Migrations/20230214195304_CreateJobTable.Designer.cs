﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TWJOBS.Core.Data.Contexts;

#nullable disable

namespace TWJOBS.Core.Data.Migrations
{
    [DbContext(typeof(TwJobsDbContext))]
    [Migration("20230214195304_CreateJobTable")]
    partial class CreateJobTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TWJOBS.Core.Models.Job", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("requerimentos")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("requerimentos");

                    b.Property<decimal>("salario")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("salario");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("titulo");

                    b.HasKey("id");

                    b.ToTable("jobs", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
