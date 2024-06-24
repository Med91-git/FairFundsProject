﻿// <auto-generated />
using System;
using FairFunds.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FairFunds.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240606094034_AjoutTableCategorieEtDepense")]
    partial class AjoutTableCategorieEtDepense
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FairFunds.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieID"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FairFunds.Models.Depense", b =>
                {
                    b.Property<int>("DepenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepenseID"));

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepenseID");

                    b.ToTable("Depenses");
                });
#pragma warning restore 612, 618
        }
    }
}
