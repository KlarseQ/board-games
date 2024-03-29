﻿// <auto-generated />
using System;
using DataBaseMinimalApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBaseMinimalApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240113220531_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.DBO.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CardDeckId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<int?>("IntValue")
                        .HasColumnType("integer");

                    b.Property<string>("TextValue")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CardDeckId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Models.DBO.CardDeck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("GameId")
                        .HasColumnType("integer");

                    b.Property<int?>("SessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("SessionId")
                        .IsUnique();

                    b.ToTable("CardDecks");
                });

            modelBuilder.Entity("Models.DBO.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("InitCount")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Models.DBO.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("LastSessionId")
                        .HasColumnType("integer");

                    b.Property<int>("LoseCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("WinCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LastSessionId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Models.DBO.PlayerMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int?>("SessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SessionId");

                    b.ToTable("PlayerMoves");
                });

            modelBuilder.Entity("Models.DBO.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CardDeckId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("GameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Models.DBO.Card", b =>
                {
                    b.HasOne("Models.DBO.CardDeck", null)
                        .WithMany("Cards")
                        .HasForeignKey("CardDeckId");
                });

            modelBuilder.Entity("Models.DBO.CardDeck", b =>
                {
                    b.HasOne("Models.DBO.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("Models.DBO.Session", "Session")
                        .WithOne("CardDeck")
                        .HasForeignKey("Models.DBO.CardDeck", "SessionId");

                    b.Navigation("Game");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Models.DBO.Player", b =>
                {
                    b.HasOne("Models.DBO.Session", "LastSession")
                        .WithMany("Players")
                        .HasForeignKey("LastSessionId");

                    b.Navigation("LastSession");
                });

            modelBuilder.Entity("Models.DBO.PlayerMove", b =>
                {
                    b.HasOne("Models.DBO.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("Models.DBO.Session", "Session")
                        .WithMany("PlayerMoves")
                        .HasForeignKey("SessionId");

                    b.Navigation("Player");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Models.DBO.Session", b =>
                {
                    b.HasOne("Models.DBO.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Models.DBO.CardDeck", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("Models.DBO.Session", b =>
                {
                    b.Navigation("CardDeck");

                    b.Navigation("PlayerMoves");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
