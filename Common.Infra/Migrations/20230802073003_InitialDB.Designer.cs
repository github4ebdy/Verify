﻿// <auto-generated />
using Common.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Common.Infra.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20230802073003_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Common.Entity.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("Active");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CityName");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Code");

                    b.Property<long>("District_Id")
                        .HasColumnType("bigint")
                        .HasColumnName("District_Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("District_Id");

                    b.ToTable("City", "Base");
                });

            modelBuilder.Entity("Common.Entity.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CountryCode");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CountryName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Parent", "Base");
                });

            modelBuilder.Entity("Common.Entity.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Code");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("DistrictName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<long>("State_Id")
                        .HasColumnType("bigint")
                        .HasColumnName("State_Id");

                    b.HasKey("Id");

                    b.HasIndex("State_Id");

                    b.ToTable("District", "Base");
                });

            modelBuilder.Entity("Common.Entity.State", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Code");

                    b.Property<long>("Country_Id")
                        .HasColumnType("bigint")
                        .HasColumnName("Country_Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("StateName");

                    b.HasKey("Id");

                    b.HasIndex("Country_Id");

                    b.ToTable("State", "Base");
                });

            modelBuilder.Entity("Common.Entity.City", b =>
                {
                    b.HasOne("Common.Entity.District", "District")
                        .WithMany("CityList")
                        .HasForeignKey("District_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("Common.Entity.District", b =>
                {
                    b.HasOne("Common.Entity.State", "State")
                        .WithMany("DistrictList")
                        .HasForeignKey("State_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Common.Entity.State", b =>
                {
                    b.HasOne("Common.Entity.Country", "Country")
                        .WithMany("StateList")
                        .HasForeignKey("Country_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Common.Entity.Country", b =>
                {
                    b.Navigation("StateList");
                });

            modelBuilder.Entity("Common.Entity.District", b =>
                {
                    b.Navigation("CityList");
                });

            modelBuilder.Entity("Common.Entity.State", b =>
                {
                    b.Navigation("DistrictList");
                });
#pragma warning restore 612, 618
        }
    }
}
