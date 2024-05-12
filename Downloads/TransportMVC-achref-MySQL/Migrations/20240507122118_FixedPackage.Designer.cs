﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportMVC.Data;

#nullable disable

namespace TransportMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240507122118_FixedPackage")]
    partial class FixedPackage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AssociatedPackageId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NumberOfTravellers")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedPackageId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Coordinator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coordinators");
                });

            modelBuilder.Entity("Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Destination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedById")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<Guid?>("CouponId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedById")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Services")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TransportCompany")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TransportOption")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DestinationId");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AssociatedPackageId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedById")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedPackageId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WishForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AdditionalNotes")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Destination")
                        .HasColumnType("longtext");

                    b.Property<string>("Duration")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Interests")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("WishForms");
                });

            modelBuilder.Entity("Booking", b =>
                {
                    b.HasOne("Package", "AssociatedPackage")
                        .WithMany("Bookings")
                        .HasForeignKey("AssociatedPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "CreatedBy")
                        .WithMany("Bookings")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "LastModifiedBy")
                        .WithMany("ModifiedBookings")
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedPackage");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("Coupon", b =>
                {
                    b.HasOne("User", "CreatedBy")
                        .WithMany("Coupons")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "LastModifiedBy")
                        .WithMany("ModifiedCoupons")
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("Destination", b =>
                {
                    b.HasOne("User", "CreatedBy")
                        .WithMany("Destinations")
                        .HasForeignKey("CreatedById");

                    b.HasOne("User", "LastModifiedBy")
                        .WithMany("ModifiedDestinations")
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Notification", b =>
                {
                    b.HasOne("User", "CreatedBy")
                        .WithMany("SentNotifications")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "LastModifiedBy")
                        .WithMany("ModifiedNotifications")
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "Receiver")
                        .WithMany("ReceivedNotifications")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Package", b =>
                {
                    b.HasOne("Coupon", null)
                        .WithMany("ApplicablePackages")
                        .HasForeignKey("CouponId");

                    b.HasOne("User", "CreatedBy")
                        .WithMany("Packages")
                        .HasForeignKey("CreatedById");

                    b.HasOne("Destination", "Destination")
                        .WithMany("Packages")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "LastModifiedBy")
                        .WithMany("ModifiedPackages")
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("Destination");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("Review", b =>
                {
                    b.HasOne("Package", "AssociatedPackage")
                        .WithMany("Reviews")
                        .HasForeignKey("AssociatedPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "CreatedBy")
                        .WithMany("Reviews")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "LastModifiedBy")
                        .WithMany("ModifiedReviews")
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedPackage");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("WishForm", b =>
                {
                    b.HasOne("User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Coupon", b =>
                {
                    b.Navigation("ApplicablePackages");
                });

            modelBuilder.Entity("Destination", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Package", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Coupons");

                    b.Navigation("Destinations");

                    b.Navigation("ModifiedBookings");

                    b.Navigation("ModifiedCoupons");

                    b.Navigation("ModifiedDestinations");

                    b.Navigation("ModifiedNotifications");

                    b.Navigation("ModifiedPackages");

                    b.Navigation("ModifiedReviews");

                    b.Navigation("Packages");

                    b.Navigation("ReceivedNotifications");

                    b.Navigation("Reviews");

                    b.Navigation("SentNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}
