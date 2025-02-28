﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Cecilious.Data;

#nullable disable

namespace Project_Cecilious.Migrations
{
    [DbContext(typeof(CeciliousContext))]
    [Migration("20240717184346_check")]
    partial class check
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project_Cecilious.Model.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DishCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkToShoppe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("DishId");

                    b.HasIndex("DishCategoryId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dish", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.DishCategory", b =>
                {
                    b.Property<int>("DishCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DishCategoryId");

                    b.ToTable("DishCategory", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.DishImage", b =>
                {
                    b.Property<int>("DishImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DishImageID"));

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DishImageID");

                    b.HasIndex("DishId");

                    b.ToTable("DishImages");
                });

            modelBuilder.Entity("Project_Cecilious.Model.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantAddressId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId");

                    b.HasIndex("RestaurantAddressId");

                    b.HasIndex("RestaurantCategoryId");

                    b.ToTable("Restaurant", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.RestaurantAddress", b =>
                {
                    b.Property<int>("RestaurantAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantAddressId"));

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleMapLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantAddressId");

                    b.ToTable("RestaurantAddress", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.RestaurantCategory", b =>
                {
                    b.Property<int>("RestaurantCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantCategoryId");

                    b.ToTable("RestaurantCategory", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.RestaurantImage", b =>
                {
                    b.Property<int>("ResImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResImageID"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("ResImageID");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantImages");
                });

            modelBuilder.Entity("Project_Cecilious.Model.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Project_Cecilious.Model.Account", b =>
                {
                    b.HasOne("Project_Cecilious.Model.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Project_Cecilious.Model.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Cecilious.Model.Dish", b =>
                {
                    b.HasOne("Project_Cecilious.Model.DishCategory", "DishCategory")
                        .WithMany("Dishes")
                        .HasForeignKey("DishCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Cecilious.Model.Restaurant", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DishCategory");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Project_Cecilious.Model.DishImage", b =>
                {
                    b.HasOne("Project_Cecilious.Model.Dish", null)
                        .WithMany("DishImages")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project_Cecilious.Model.Restaurant", b =>
                {
                    b.HasOne("Project_Cecilious.Model.RestaurantAddress", "RestaurantAddress")
                        .WithMany("Restaurants")
                        .HasForeignKey("RestaurantAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Cecilious.Model.RestaurantCategory", "RestaurantCategory")
                        .WithMany("Restaurants")
                        .HasForeignKey("RestaurantCategoryId");

                    b.Navigation("RestaurantAddress");

                    b.Navigation("RestaurantCategory");
                });

            modelBuilder.Entity("Project_Cecilious.Model.RestaurantImage", b =>
                {
                    b.HasOne("Project_Cecilious.Model.Restaurant", null)
                        .WithMany("RestaurantImages")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project_Cecilious.Model.Review", b =>
                {
                    b.HasOne("Project_Cecilious.Model.Restaurant", "Restaurant")
                        .WithMany("Review")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Cecilious.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Cecilious.Model.Dish", b =>
                {
                    b.Navigation("DishImages");
                });

            modelBuilder.Entity("Project_Cecilious.Model.DishCategory", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Project_Cecilious.Model.Restaurant", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("RestaurantImages");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Project_Cecilious.Model.RestaurantAddress", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Project_Cecilious.Model.RestaurantCategory", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Project_Cecilious.Model.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
