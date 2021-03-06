// <auto-generated />
using System;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220416193240_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFDataAccessLibrary.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(10)");

                    b.HasKey("AddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Biling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("ItemPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("TotalCost")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Bilings");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(450)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BilingId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BilingId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Taxe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BilingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxeRate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BilingId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Address", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Customer", null)
                        .WithMany("addresses")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Discount", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Biling", null)
                        .WithMany("Discounts")
                        .HasForeignKey("BilingId");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Taxe", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Biling", null)
                        .WithMany("Taxes")
                        .HasForeignKey("BilingId");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Biling", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Taxes");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Customer", b =>
                {
                    b.Navigation("addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
