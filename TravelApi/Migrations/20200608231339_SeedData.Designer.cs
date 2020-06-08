﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApi.Models;

namespace TravelApi.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    [Migration("20200608231339_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelApi.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<double>("Rating");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            City = "Tokyo",
                            Country = "Japan",
                            Rating = 2.0
                        },
                        new
                        {
                            PlaceId = 2,
                            City = "Seattle",
                            Country = "US",
                            Rating = 4.0
                        },
                        new
                        {
                            PlaceId = 3,
                            City = "London",
                            Country = "England",
                            Rating = 3.0
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlaceId");

                    b.Property<double>("Rating");

                    b.Property<string>("ReviewText");

                    b.HasKey("ReviewId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            PlaceId = 1,
                            Rating = 2.0,
                            ReviewText = "Great!"
                        },
                        new
                        {
                            ReviewId = 2,
                            PlaceId = 2,
                            Rating = 1.0,
                            ReviewText = "I hated this place!"
                        },
                        new
                        {
                            ReviewId = 3,
                            PlaceId = 3,
                            Rating = 4.0,
                            ReviewText = "Highly recommend!!"
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.HasOne("TravelApi.Models.Place", "Place")
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
