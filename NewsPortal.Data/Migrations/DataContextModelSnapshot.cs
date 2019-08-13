﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsPortal.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NewsPortal.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NewsPortal.Models.Data.News", b =>
                {
                    b.Property<Guid>("NewsId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Headline");

                    b.Property<byte>("Photo");

                    b.Property<string>("Review");

                    b.Property<string>("Text");

                    b.HasKey("NewsId");

                    b.ToTable("Newss");
                });
#pragma warning restore 612, 618
        }
    }
}