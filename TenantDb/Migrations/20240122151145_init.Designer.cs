﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TenantDb.Migrations
{
    [DbContext(typeof(TenantDbContext))]
    [Migration("20240122151145_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TenantDb.Tenant.Data.Entity.DailyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Chassis")
                        .HasColumnType("integer");

                    b.Property<string>("ContainerNumber")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<bool>("IsCollect")
                        .HasColumnType("boolean")
                        .HasComment("是否領取");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHandOver")
                        .HasColumnType("boolean")
                        .HasComment("是否交櫃");

                    b.Property<bool>("IsReceived")
                        .HasColumnType("boolean")
                        .HasComment("是否收穫");

                    b.Property<bool>("IsSend")
                        .HasColumnType("boolean")
                        .HasComment("是否送達");

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnType("numeric")
                        .HasComment("運費");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("DailyReport", t =>
                        {
                            t.HasComment("日報表");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}