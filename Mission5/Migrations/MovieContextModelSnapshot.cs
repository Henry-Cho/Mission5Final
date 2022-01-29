﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission5.Models;

namespace Mission5.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Mission5.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Categoryid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(4);

                    b.HasKey("MovieId");

                    b.HasIndex("Categoryid");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Categoryid = 1,
                            Director = "Chris Columbus",
                            Edited = false,
                            LentTo = "Logan Kim",
                            Note = "For FHE",
                            Rating = "PG",
                            Title = "Harry Potter and the Chamber of Secrets",
                            Year = "2002"
                        },
                        new
                        {
                            MovieId = 2,
                            Categoryid = 2,
                            Director = "Jon Favreau",
                            Edited = false,
                            LentTo = "Wayne Park",
                            Note = "For his dating",
                            Rating = "PG-13",
                            Title = "Iron Man",
                            Year = "2008"
                        },
                        new
                        {
                            MovieId = 3,
                            Categoryid = 3,
                            Director = "Richard Curtis",
                            Edited = true,
                            LentTo = "Yes",
                            Note = "For fun",
                            Rating = "R",
                            Title = "About Time",
                            Year = "2013"
                        });
                });

            modelBuilder.Entity("Mission5.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Family"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Horror/Suspense"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Television"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "VHS"
                        });
                });

            modelBuilder.Entity("Mission5.Models.ApplicationResponse", b =>
                {
                    b.HasOne("Mission5.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
