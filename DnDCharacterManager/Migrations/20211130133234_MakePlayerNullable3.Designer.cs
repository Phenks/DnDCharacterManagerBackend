﻿// <auto-generated />
using System;
using DnDCharacterManager.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DnDCharacterManager.Migrations
{
    [DbContext(typeof(DnDContext))]
    [Migration("20211130133234_MakePlayerNullable3")]
    partial class MakePlayerNullable3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.CharacterDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.CurrencyDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Copper")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Electrum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gold")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Platin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Silver")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.ItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CharacterDTOId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tradeable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterDTOId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.UserDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GoogleID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.CharacterDTO", b =>
                {
                    b.HasOne("DnDCharacterManager.Models.DTO.CurrencyDTO", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDCharacterManager.Models.DTO.UserDTO", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Currency");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.ItemDTO", b =>
                {
                    b.HasOne("DnDCharacterManager.Models.DTO.CharacterDTO", null)
                        .WithMany("Items")
                        .HasForeignKey("CharacterDTOId");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.CharacterDTO", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
