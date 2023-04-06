﻿// <auto-generated />
using System;
using ARMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ARMS.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230406090300_LifeExpectancy")]
    partial class LifeExpectancy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ARMS.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ARMS.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("BeginYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EndYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ARMS.Domain.LifeExpectancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryFieldId")
                        .HasColumnType("TEXT");

                    b.Property<float>("FemaleLifeExpectancy")
                        .HasColumnType("REAL");

                    b.Property<float>("MaleLifeExpectancy")
                        .HasColumnType("REAL");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CountryFieldId");

                    b.ToTable("LifeExpectancies");
                });

            modelBuilder.Entity("ARMS.Domain.Country", b =>
                {
                    b.HasOne("ARMS.Domain.Event", null)
                        .WithMany("Countries")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("ARMS.Domain.LifeExpectancy", b =>
                {
                    b.HasOne("ARMS.Domain.Country", "CountryField")
                        .WithMany()
                        .HasForeignKey("CountryFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryField");
                });

            modelBuilder.Entity("ARMS.Domain.Event", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
