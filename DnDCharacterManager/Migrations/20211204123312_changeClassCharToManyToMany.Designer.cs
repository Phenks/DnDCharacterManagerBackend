// <auto-generated />
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
    [Migration("20211204123312_changeClassCharToManyToMany")]
    partial class changeClassCharToManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CharacterCharacterClass", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersId", "ClassesId");

                    b.HasIndex("ClassesId");

                    b.ToTable("CharacterCharacterClass");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Milestones")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.CharacterClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Classes");
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

                    b.Property<int?>("CharacterId")
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

                    b.HasIndex("CharacterId");

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

            modelBuilder.Entity("CharacterCharacterClass", b =>
                {
                    b.HasOne("DnDCharacterManager.Models.DTO.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDCharacterManager.Models.DTO.CharacterClass", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.Character", b =>
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
                    b.HasOne("DnDCharacterManager.Models.DTO.Character", null)
                        .WithMany("Items")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("DnDCharacterManager.Models.DTO.Character", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
