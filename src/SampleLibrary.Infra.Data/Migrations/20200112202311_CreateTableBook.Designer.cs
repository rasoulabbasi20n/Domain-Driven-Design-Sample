﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleLibrary.Infra.Data.Context;

namespace SampleLibrary.Infra.Data.Migrations
{
    [DbContext(typeof(SampleLibraryContext))]
    [Migration("20200112202311_CreateTableBook")]
    partial class CreateTableBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleLibrary.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("SampleLibrary.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("PublisherId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("SampleLibrary.Domain.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("SampleLibrary.Domain.Entities.Book", b =>
                {
                    b.HasOne("SampleLibrary.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SampleLibrary.Domain.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SampleLibrary.Domain.Tests.Entities.Validators.Entities.ValueObjects.Publication", "Publication", b1 =>
                        {
                            b1.Property<Guid>("BookId");

                            b1.Property<int>("Edition")
                                .HasColumnName("Edition");

                            b1.Property<int>("Year")
                                .HasColumnName("Year");

                            b1.HasKey("BookId");

                            b1.ToTable("Book");

                            b1.HasOne("SampleLibrary.Domain.Entities.Book")
                                .WithOne("Publication")
                                .HasForeignKey("SampleLibrary.Domain.Tests.Entities.Validators.Entities.ValueObjects.Publication", "BookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
