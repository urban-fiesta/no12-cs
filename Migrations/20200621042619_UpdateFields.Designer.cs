﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UrbanFiesta.Data;

namespace UrbanFiesta.Migrations
{
    [DbContext(typeof(UrbanFiestaContext))]
    [Migration("20200621042619_UpdateFields")]
    partial class UpdateFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("UrbanFiesta.Models.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ageLimit")
                        .HasColumnType("integer");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("eventPhoto")
                        .HasColumnType("text");

                    b.Property<DateTime>("finish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("local")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime>("start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("tag")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Events");
                });
#pragma warning restore 612, 618
        }
    }
}