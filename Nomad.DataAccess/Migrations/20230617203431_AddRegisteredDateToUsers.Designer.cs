﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nomad.DataAccess.Data;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230617203431_AddRegisteredDateToUsers")]
    partial class AddRegisteredDateToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nomad.DataAccess.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfNightsBooked")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("ListingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BathroomCount")
                        .HasColumnType("int");

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("BedroomCount")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasAirConditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParking")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTv")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWiFi")
                        .HasColumnType("bit");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<int>("ListingTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PrivacyTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.HasIndex("ListingTypeId");

                    b.HasIndex("PrivacyTypeId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ListingPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("ListingPhotos");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ListingReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("ReviewId");

                    b.ToTable("ListingReviews");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ListingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListingTypes");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.PrivacyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrivacyTypes");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ProfilePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ProfilePhoto");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.UserReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("UserReviewedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("UsersReviews");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.Booking", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.User", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("Nomad.DataAccess.Entities.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.Listing", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.User", "Host")
                        .WithMany()
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nomad.DataAccess.Entities.ListingType", "ListingType")
                        .WithMany()
                        .HasForeignKey("ListingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nomad.DataAccess.Entities.PrivacyType", "PrivacyType")
                        .WithMany()
                        .HasForeignKey("PrivacyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");

                    b.Navigation("ListingType");

                    b.Navigation("PrivacyType");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ListingPhoto", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.Listing", null)
                        .WithMany("Photos")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ListingReviews", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nomad.DataAccess.Entities.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.ProfilePhoto", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.Review", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.User", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.UserReviews", b =>
                {
                    b.HasOne("Nomad.DataAccess.Entities.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.Listing", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Nomad.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
