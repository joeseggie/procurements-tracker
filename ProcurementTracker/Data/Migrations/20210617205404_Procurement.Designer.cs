﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcurementTracker.Data;

namespace ProcurementTracker.Data.Migrations
{
    [DbContext(typeof(ProcurementTrackerContext))]
    [Migration("20210617205404_Procurement")]
    partial class Procurement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProcurementTracker.Models.Bid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProcurementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Submitted")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ValidPeriod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcurementId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("ProcurementTracker.Models.Procurement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcurementMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Procurement");
                });

            modelBuilder.Entity("ProcurementTracker.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("ProcurementTracker.Models.Bid", b =>
                {
                    b.HasOne("ProcurementTracker.Models.Procurement", "Procurement")
                        .WithMany("Bids")
                        .HasForeignKey("ProcurementId");

                    b.HasOne("ProcurementTracker.Models.Supplier", "Supplier")
                        .WithMany("Bids")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Procurement");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProcurementTracker.Models.Procurement", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("ProcurementTracker.Models.Supplier", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
