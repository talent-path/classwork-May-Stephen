﻿// <auto-generated />
using System;
using CardCollection.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CardCollection.Migrations
{
    [DbContext(typeof(CardDbContext))]
    [Migration("20210629213801_TradeTables")]
    partial class TradeTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CardCollection.Models.Card", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Illustrator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberInSet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfferId")
                        .HasColumnType("int");

                    b.Property<string>("Rarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("SetId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("RequestId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("CardCollection.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TradeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("CardCollection.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TradeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CardCollection.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AvailableTrades");
                });

            modelBuilder.Entity("CardCollection.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CardTrade", b =>
                {
                    b.Property<string>("CardsOfferedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TradeOffersId")
                        .HasColumnType("int");

                    b.HasKey("CardsOfferedId", "TradeOffersId");

                    b.HasIndex("TradeOffersId");

                    b.ToTable("CardTrade");
                });

            modelBuilder.Entity("CardUser", b =>
                {
                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.Property<string>("PersonalCollectionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OwnersId", "PersonalCollectionId");

                    b.HasIndex("PersonalCollectionId");

                    b.ToTable("CardUser");
                });

            modelBuilder.Entity("CardCollection.Models.Card", b =>
                {
                    b.HasOne("CardCollection.Models.Offer", null)
                        .WithMany("OfferedCards")
                        .HasForeignKey("OfferId");

                    b.HasOne("CardCollection.Models.Request", null)
                        .WithMany("RequestedCards")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("CardTrade", b =>
                {
                    b.HasOne("CardCollection.Models.Card", null)
                        .WithMany()
                        .HasForeignKey("CardsOfferedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardCollection.Models.Trade", null)
                        .WithMany()
                        .HasForeignKey("TradeOffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CardUser", b =>
                {
                    b.HasOne("CardCollection.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardCollection.Models.Card", null)
                        .WithMany()
                        .HasForeignKey("PersonalCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CardCollection.Models.Offer", b =>
                {
                    b.Navigation("OfferedCards");
                });

            modelBuilder.Entity("CardCollection.Models.Request", b =>
                {
                    b.Navigation("RequestedCards");
                });
#pragma warning restore 612, 618
        }
    }
}