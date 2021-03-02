﻿// <auto-generated />
using System;
using EfCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210302070540_Customer type v2")]
    partial class Customertypev2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("CustomerGroup", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomersId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("CustomerGroup");
                });

            modelBuilder.Entity("EfCoreDemo.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EfCoreDemo.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EfCoreDemo.Models.SchoolCustomer", b =>
                {
                    b.HasBaseType("EfCoreDemo.Models.Customer");

                    b.Property<string>("SchoolName")
                        .HasColumnType("TEXT");

                    b.ToTable("SchoolCustomers");
                });

            modelBuilder.Entity("EfCoreDemo.Models.VipCustomer", b =>
                {
                    b.HasBaseType("EfCoreDemo.Models.Customer");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.ToTable("VipCustomers");
                });

            modelBuilder.Entity("CustomerGroup", b =>
                {
                    b.HasOne("EfCoreDemo.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreDemo.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreDemo.Models.SchoolCustomer", b =>
                {
                    b.HasOne("EfCoreDemo.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("EfCoreDemo.Models.SchoolCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreDemo.Models.VipCustomer", b =>
                {
                    b.HasOne("EfCoreDemo.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("EfCoreDemo.Models.VipCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
