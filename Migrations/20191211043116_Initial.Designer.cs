﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QinMilitary.Data;

namespace QinMilitary.Migrations
{
    [DbContext(typeof(QMContext))]
    [Migration("20191211043116_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QinMilitary.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Battle");

                    b.Property<string>("Description");

                    b.Property<string>("Reward");

                    b.Property<int>("SolderID");

                    b.Property<int?>("SoldierID");

                    b.HasKey("AchievementID");

                    b.HasIndex("SoldierID");

                    b.ToTable("Achievement");
                });

            modelBuilder.Entity("QinMilitary.Models.Assignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfficerID");

                    b.Property<int>("SoldierID");

                    b.HasKey("ID");

                    b.HasIndex("OfficerID");

                    b.HasIndex("SoldierID");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("QinMilitary.Models.Officer", b =>
                {
                    b.Property<int>("OfficerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Rank");

                    b.Property<string>("Status");

                    b.Property<int>("Years");

                    b.HasKey("OfficerID");

                    b.ToTable("Officer");
                });

            modelBuilder.Entity("QinMilitary.Models.Soldier", b =>
                {
                    b.Property<int>("SoldierID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Birthplace");

                    b.Property<int?>("COOfficerID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Status");

                    b.Property<int>("UnitID");

                    b.HasKey("SoldierID");

                    b.HasIndex("COOfficerID");

                    b.HasIndex("UnitID");

                    b.ToTable("Soldier");
                });

            modelBuilder.Entity("QinMilitary.Models.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Numbers");

                    b.Property<int?>("OfficerID");

                    b.HasKey("UnitID");

                    b.HasIndex("OfficerID");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("QinMilitary.Models.Achievement", b =>
                {
                    b.HasOne("QinMilitary.Models.Soldier", "Soldier")
                        .WithMany("Achievements")
                        .HasForeignKey("SoldierID");
                });

            modelBuilder.Entity("QinMilitary.Models.Assignment", b =>
                {
                    b.HasOne("QinMilitary.Models.Officer", "Officer")
                        .WithMany()
                        .HasForeignKey("OfficerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QinMilitary.Models.Soldier", "Soldier")
                        .WithMany()
                        .HasForeignKey("SoldierID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QinMilitary.Models.Soldier", b =>
                {
                    b.HasOne("QinMilitary.Models.Officer", "CO")
                        .WithMany()
                        .HasForeignKey("COOfficerID");

                    b.HasOne("QinMilitary.Models.Unit", "Unit")
                        .WithMany("Soldiers")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QinMilitary.Models.Unit", b =>
                {
                    b.HasOne("QinMilitary.Models.Officer", "Admin")
                        .WithMany()
                        .HasForeignKey("OfficerID");
                });
#pragma warning restore 612, 618
        }
    }
}
