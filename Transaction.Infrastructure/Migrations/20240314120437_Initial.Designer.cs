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
    [Migration("20240314120437_Initial")]
    partial class Initial
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
                    b.Property<string>("Transaction_Id")
                        .HasColumnType("text");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Client_Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Transaction_Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Transaction_Id");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
