﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Context.Migrations
{
    [DbContext(typeof(DBModels))]
    partial class DBModelsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Models.SubscriptionType", b =>
                {
                    b.Property<Guid>("SubscriptionTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<short>("Duration")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SubscriptionTypeID");

                    b.ToTable("subscriptiontype", (string)null);
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastAttend")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SubscriptionFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("SubscriptionTo")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserID");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Models.UserSubscription", b =>
                {
                    b.Property<Guid>("UserSubscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<short>("DaysRemaining")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("SubscriptionTypeID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("UserSubscriptionID");

                    b.HasIndex("SubscriptionTypeID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("usersubscription", (string)null);
                });

            modelBuilder.Entity("Models.UserSubscriptionHistory", b =>
                {
                    b.Property<Guid>("UserSubscriptionHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("SubscriptionFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("SubscriptionTo")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("SubscriptionTypeID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("UserSubscriptionHistoryID");

                    b.HasIndex("SubscriptionTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("usersubscriptionhistory", (string)null);
                });

            modelBuilder.Entity("Models.UserSubscription", b =>
                {
                    b.HasOne("Models.SubscriptionType", "SubscriptionType")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("SubscriptionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithOne("UserSubscription")
                        .HasForeignKey("Models.UserSubscription", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.UserSubscriptionHistory", b =>
                {
                    b.HasOne("Models.SubscriptionType", "SubscriptionType")
                        .WithMany("UserSubscriptionsHistory")
                        .HasForeignKey("SubscriptionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.SubscriptionType", b =>
                {
                    b.Navigation("UserSubscriptions");

                    b.Navigation("UserSubscriptionsHistory");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("UserSubscription")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
