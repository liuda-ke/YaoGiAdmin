﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YaoGiAdmin.Models;

namespace YaoGiAdmin.Models.Migrations
{
    [DbContext(typeof(BuildingDbContext))]
    partial class BuildingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YaoGiAdmin.Models.Sys.SysUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IsDel")
                        .HasColumnType("INT");

                    b.Property<string>("UserAccount")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("UserBirthday")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<int>("UserGender")
                        .HasColumnType("INT");

                    b.Property<string>("UserMobile")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("UserName")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("UserPhoto")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("UserQQ")
                        .HasColumnType("NVARCHAR(11)");

                    b.Property<string>("UserWeChat")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("WebToken")
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("SysUser");
                });

            modelBuilder.Entity("YaoGiAdmin.Models.Tools.GenerateColumns", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ColumnName")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("ColumnType")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<Guid>("GenerateTablesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDel")
                        .HasColumnType("INT");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("OldColumnName")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("OldColumnType")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<Guid?>("SysUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenerateTablesId");

                    b.HasIndex("SysUserId");

                    b.ToTable("GenerateColumns");
                });

            modelBuilder.Entity("YaoGiAdmin.Models.Tools.GenerateTables", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Descrption")
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<int>("IsDel")
                        .HasColumnType("INT");

                    b.Property<int>("IsGenerate")
                        .HasColumnType("INT");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("SysUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TableCNName")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("TableName")
                        .HasColumnType("NVARCHAR(200)");

                    b.HasKey("Id");

                    b.HasIndex("SysUserId");

                    b.ToTable("GenerateTables");
                });

            modelBuilder.Entity("YaoGiAdmin.Models.Tools.GenerateColumns", b =>
                {
                    b.HasOne("YaoGiAdmin.Models.Tools.GenerateTables", "GenerateTables")
                        .WithMany("GenerateColumns")
                        .HasForeignKey("GenerateTablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YaoGiAdmin.Models.Sys.SysUser", "SysUser")
                        .WithMany()
                        .HasForeignKey("SysUserId");
                });

            modelBuilder.Entity("YaoGiAdmin.Models.Tools.GenerateTables", b =>
                {
                    b.HasOne("YaoGiAdmin.Models.Sys.SysUser", "SysUser")
                        .WithMany()
                        .HasForeignKey("SysUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
