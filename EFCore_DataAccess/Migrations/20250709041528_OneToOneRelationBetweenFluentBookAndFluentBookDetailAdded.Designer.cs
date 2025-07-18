﻿// <auto-generated />
using System;
using EFCore_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250709041528_OneToOneRelationBetweenFluentBookAndFluentBookDetailAdded")]
    partial class OneToOneRelationBetweenFluentBookAndFluentBookDetailAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCore_Models.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EFCore_Models.Models.Book", b =>
                {
                    b.Property<int>("IDBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDBook"));

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Book_ISBN");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 6)
                        .HasColumnType("decimal(10,6)");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDBook");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("TBL_Books");

                    b.HasData(
                        new
                        {
                            IDBook = 1,
                            ISBN = "123456",
                            Price = 10.99m,
                            Publisher_Id = 1,
                            Title = "Spider Without Duty"
                        },
                        new
                        {
                            IDBook = 2,
                            ISBN = "123456456",
                            Price = 11.99m,
                            Publisher_Id = 2,
                            Title = "Fortune Of Time"
                        },
                        new
                        {
                            IDBook = 3,
                            ISBN = "123456789",
                            Price = 20.99m,
                            Publisher_Id = 2,
                            Title = "Fake Sunday"
                        },
                        new
                        {
                            IDBook = 4,
                            ISBN = "0123456789",
                            Price = 25.99m,
                            Publisher_Id = 3,
                            Title = "Cookie Jar"
                        },
                        new
                        {
                            IDBook = 5,
                            ISBN = "1234567890",
                            Price = 40.99m,
                            Publisher_Id = 3,
                            Title = "Cloudy Forest"
                        });
                });

            modelBuilder.Entity("EFCore_Models.Models.BookAuthorMapping", b =>
                {
                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.HasKey("Author_Id", "Book_Id");

                    b.HasIndex("Book_Id");

                    b.ToTable("BookAuthorMapping");
                });

            modelBuilder.Entity("EFCore_Models.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("EFCore_Models.Models.Fluent_Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Fluent_Authors");
                });

            modelBuilder.Entity("EFCore_Models.Models.Fluent_Book", b =>
                {
                    b.Property<int>("IDBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDBook"));

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Fluent_Book_ISBN");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDBook");

                    b.ToTable("TBL_FluentBooks", (string)null);
                });

            modelBuilder.Entity("EFCore_Models.Models.Fluent_BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int")
                        .HasColumnName("NoOfChapters");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("Fluent_BookDetails", (string)null);
                });

            modelBuilder.Entity("EFCore_Models.Models.Fluent_Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Fluent_Publishers");
                });

            modelBuilder.Entity("EFCore_Models.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("EFCore_Models.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Publisher_Id = 1,
                            Location = "Chicago",
                            Name = "Pub 1 Jimmy"
                        },
                        new
                        {
                            Publisher_Id = 2,
                            Location = "New York",
                            Name = "Pub 2 John"
                        },
                        new
                        {
                            Publisher_Id = 3,
                            Location = "Hawaii",
                            Name = "Pub 1 Ben"
                        });
                });

            modelBuilder.Entity("EFCore_Models.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategory_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubCategory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EFCore_Models.Models.Book", b =>
                {
                    b.HasOne("EFCore_Models.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("EFCore_Models.Models.BookAuthorMapping", b =>
                {
                    b.HasOne("EFCore_Models.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore_Models.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EFCore_Models.Models.BookDetail", b =>
                {
                    b.HasOne("EFCore_Models.Models.Book", "Book")
                        .WithOne("Details")
                        .HasForeignKey("EFCore_Models.Models.BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EFCore_Models.Models.Fluent_BookDetail", b =>
                {
                    b.HasOne("EFCore_Models.Models.Fluent_Book", "Book")
                        .WithOne("Details")
                        .HasForeignKey("EFCore_Models.Models.Fluent_BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EFCore_Models.Models.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("EFCore_Models.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("EFCore_Models.Models.Fluent_Book", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("EFCore_Models.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
