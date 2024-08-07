﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using budget.Repo;

#nullable disable

namespace budget.Repo.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20240725185325_InitalCreate")]
    partial class InitalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("budget.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryID");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("budget.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<string>("TransactionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("budget.Models.Transaction", b =>
                {
                    b.HasOne("budget.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
