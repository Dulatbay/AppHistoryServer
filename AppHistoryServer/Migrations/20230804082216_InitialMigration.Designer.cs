﻿// <auto-generated />
using System;
using AppHistoryServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppHistoryServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230804082216_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppHistoryServer.Dtos.ContentDtos.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Component")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("Minutes")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ModuleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("contentId")
                        .HasColumnType("integer");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("contentId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("AppHistoryServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastPlay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("League")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShockDay")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("lastTopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("lastTopicId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Question", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Module", null)
                        .WithMany("Questions")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Topic", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Dtos.ContentDtos.Node", "content")
                        .WithMany()
                        .HasForeignKey("contentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("content");
                });

            modelBuilder.Entity("AppHistoryServer.Models.User", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Topic", "lastTopic")
                        .WithMany()
                        .HasForeignKey("lastTopicId");

                    b.Navigation("lastTopic");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Module", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
