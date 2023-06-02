﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230602164755_CreateForumDbContext")]
    partial class CreateForumDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Forum.Data.Model.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b64aea3-2b1f-4265-8a94-029b9aeee3c6"),
                            Content = "First Post Content",
                            Title = "First Post"
                        },
                        new
                        {
                            Id = new Guid("1eb65deb-ac99-4c2f-a15b-68f097d453c1"),
                            Content = "Second Post Content",
                            Title = "Second Post"
                        },
                        new
                        {
                            Id = new Guid("cd4bdcc3-e982-48be-97f0-caea45d41905"),
                            Content = "Third Post Content",
                            Title = "Third Post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
