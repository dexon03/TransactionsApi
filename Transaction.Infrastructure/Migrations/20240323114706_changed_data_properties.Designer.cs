﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Transaction.Infrastructure;

#nullable disable

namespace Transaction.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240323114706_changed_data_properties")]
    partial class changed_data_properties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Transaction.Models.Transaction.Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("text")
                        .HasColumnName("transactionId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<string>("ClientLocation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("clientLocation");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("TimeZoneId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("timeZoneId");

                    b.Property<DateTimeOffset>("UtcTransactionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("utcTransactionDate");

                    b.HasKey("TransactionId");

                    b.ToTable("transactions");
                });
#pragma warning restore 612, 618
        }
    }
}