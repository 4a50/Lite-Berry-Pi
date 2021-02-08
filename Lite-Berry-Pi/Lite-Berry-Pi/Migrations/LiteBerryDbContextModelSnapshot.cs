﻿// <auto-generated />
using System;
using Lite_Berry_Pi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lite_Berry_Pi.Migrations
{
    [DbContext(typeof(LiteBerryDbContext))]
    partial class LiteBerryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lite_Berry_Pi.Models.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("Lite_Berry_Pi.Models.Design", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityLogId")
                        .HasColumnType("int");

                    b.Property<string>("DesignCoords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserDesignDesignId")
                        .HasColumnType("int");

                    b.Property<int?>("UserDesignUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityLogId");

                    b.HasIndex("UserDesignUserId", "UserDesignDesignId");

                    b.ToTable("Design");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesignCoords = "000011111",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Test1"
                        },
                        new
                        {
                            Id = 2,
                            DesignCoords = "10011001",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Test2"
                        },
                        new
                        {
                            Id = 3,
                            DesignCoords = "100010101",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Test3"
                        });
                });

            modelBuilder.Entity("Lite_Berry_Pi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bruno"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Elwood"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jake"
                        });
                });

            modelBuilder.Entity("Lite_Berry_Pi.Models.UserDesign", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("DesignId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "DesignId");

                    b.ToTable("UserDesign");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DesignId = 1
                        },
                        new
                        {
                            UserId = 2,
                            DesignId = 2
                        },
                        new
                        {
                            UserId = 3,
                            DesignId = 3
                        });
                });

            modelBuilder.Entity("Lite_Berry_Pi.Models.ActivityLog", b =>
                {
                    b.HasOne("Lite_Berry_Pi.Models.User", "User")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Lite_Berry_Pi.Models.Design", b =>
                {
                    b.HasOne("Lite_Berry_Pi.Models.ActivityLog", null)
                        .WithMany("Designs")
                        .HasForeignKey("ActivityLogId");

                    b.HasOne("Lite_Berry_Pi.Models.UserDesign", "UserDesign")
                        .WithMany("Designs")
                        .HasForeignKey("UserDesignUserId", "UserDesignDesignId");
                });

            modelBuilder.Entity("Lite_Berry_Pi.Models.UserDesign", b =>
                {
                    b.HasOne("Lite_Berry_Pi.Models.User", "User")
                        .WithMany("UserDesigns")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
