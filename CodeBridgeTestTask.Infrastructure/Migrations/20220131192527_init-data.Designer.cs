﻿// <auto-generated />
using CodeBridgeTestTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeBridgeTestTask.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220131192527_init-data")]
    partial class initdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeBridgeTestTask.Core.Entities.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TailLength")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "red & amber",
                            Name = "Neo",
                            TailLength = 22,
                            Weight = 32
                        },
                        new
                        {
                            Id = 2,
                            Color = "black & white",
                            Name = "Jessy",
                            TailLength = 7,
                            Weight = 14
                        },
                        new
                        {
                            Id = 3,
                            Color = "black",
                            Name = "Donie",
                            TailLength = 20,
                            Weight = 17
                        },
                        new
                        {
                            Id = 4,
                            Color = "brown",
                            Name = "Tom",
                            TailLength = 17,
                            Weight = 25
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
