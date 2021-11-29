﻿// <auto-generated />
using System;
using Juros.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Juros.Infra.Migrations
{
    [DbContext(typeof(JurosContext))]
    partial class JurosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Juros.Domain.Entities.TaxaJuros", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Taxa")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("TaxaJuros");
                });
#pragma warning restore 612, 618
        }
    }
}