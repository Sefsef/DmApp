﻿// <auto-generated />
using System;
using DmApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DmApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("DmApi.Models.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CastingTime");

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<int>("Level");

                    b.Property<string>("Materials");

                    b.Property<string>("Name");

                    b.Property<int>("Range");

                    b.Property<string>("School");

                    b.Property<bool>("Somatic");

                    b.Property<bool>("Verbal");

                    b.HasKey("Id");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("DmApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Roles");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, FirstName = "Severin", LastName = "Fitriyadi", PasswordHash = new byte[] { 204, 162, 230, 211, 128, 152, 253, 149, 227, 98, 81, 196, 132, 109, 127, 244, 160, 187, 205, 202, 81, 5, 139, 7, 156, 133, 244, 18, 143, 160, 6, 41, 1, 184, 229, 202, 84, 76, 84, 222, 25, 156, 110, 55, 156, 36, 170, 255, 239, 88, 26, 72, 19, 117, 190, 189, 101, 193, 67, 65, 176, 246, 120, 143 }, PasswordSalt = new byte[] { 180, 196, 235, 222, 109, 187, 28, 175, 246, 117, 151, 188, 62, 228, 139, 208, 105, 36, 151, 52, 143, 234, 119, 164, 216, 212, 22, 69, 69, 90, 1, 102, 210, 168, 187, 7, 23, 201, 0, 213, 33, 97, 83, 174, 36, 246, 180, 102, 219, 205, 202, 199, 6, 87, 19, 180, 51, 83, 239, 118, 14, 137, 43, 204, 53, 183, 211, 136, 210, 78, 219, 169, 160, 182, 116, 158, 186, 69, 7, 185, 165, 29, 148, 255, 216, 168, 67, 168, 243, 132, 70, 37, 140, 197, 105, 141, 160, 76, 62, 117, 152, 94, 166, 73, 185, 231, 217, 241, 22, 29, 136, 30, 201, 190, 51, 84, 25, 118, 194, 69, 30, 200, 72, 249, 134, 109, 0, 136 }, Roles = "Admin,Dm,Player", Username = "admin" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
