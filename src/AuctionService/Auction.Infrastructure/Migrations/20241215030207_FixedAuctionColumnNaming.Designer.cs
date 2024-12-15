﻿// <auto-generated />
using System;
using Auction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auction.Infrastructure.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20241215030207_FixedAuctionColumnNaming")]
    partial class FixedAuctionColumnNaming
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auction.Domain.Auctions.AuctionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("AuctionEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("auction_end");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 12, 15, 3, 2, 6, 786, DateTimeKind.Utc).AddTicks(9663))
                        .HasColumnName("created_at");

                    b.Property<decimal?>("CurrentHighBid")
                        .HasColumnType("numeric")
                        .HasColumnName("current_high_bid");

                    b.Property<decimal>("ReservePrice")
                        .HasColumnType("numeric")
                        .HasColumnName("reserve_price");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("seller");

                    b.Property<decimal?>("SoldAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("sold_amount");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 12, 15, 3, 2, 6, 787, DateTimeKind.Utc).AddTicks(9574))
                        .HasColumnName("updated_at");

                    b.Property<string>("Winner")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("winner");

                    b.HasKey("Id")
                        .HasName("pk_auctions_id");

                    b.ToTable("auctions", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Items.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("color");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("image_url");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("make");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer")
                        .HasColumnName("mileage");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("model");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_items_id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Items.ItemEntity", b =>
                {
                    b.HasOne("Auction.Domain.Auctions.AuctionEntity", "AuctionEntity")
                        .WithOne("ItemEntity")
                        .HasForeignKey("Auction.Domain.Items.ItemEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_auctions_items_item_id");

                    b.Navigation("AuctionEntity");
                });

            modelBuilder.Entity("Auction.Domain.Auctions.AuctionEntity", b =>
                {
                    b.Navigation("ItemEntity")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
