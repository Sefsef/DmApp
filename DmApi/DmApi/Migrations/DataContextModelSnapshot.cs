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

                    b.HasData(
                        new { Id = 1, CastingTime = "1 action", Description = "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one. The fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried. At Higher Levels.When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.", Duration = "Instantaneous", Level = 3, Materials = "a tiny ball of bat guano and sulfur", Name = "Fireball", Range = 150, School = "evocation", Somatic = true, Verbal = true },
                        new { Id = 2, CastingTime = "1 action", Description = "You hurl a mote of fire at a creature or object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 fire damage. A flammable object hit by this spell ignites if it isn't being worn or carried. This spell's damage increases by 1d10 when you reach 5th level (2d10), 11th level (3d10), and 17th level (4d10).", Duration = "Instantaneous", Level = 0, Materials = "", Name = "Fire Bolt", Range = 120, School = "evocation", Somatic = true, Verbal = true }
                    );
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
                        new { Id = 1, FirstName = "Severin", LastName = "Fitriyadi", PasswordHash = new byte[] { 56, 110, 128, 209, 200, 255, 207, 72, 5, 217, 170, 136, 249, 191, 250, 123, 252, 23, 143, 121, 53, 92, 212, 9, 101, 87, 105, 163, 144, 47, 82, 231, 144, 171, 143, 241, 227, 69, 93, 225, 92, 87, 254, 188, 233, 222, 165, 73, 164, 152, 82, 2, 57, 176, 171, 21, 27, 107, 115, 240, 79, 207, 193, 49 }, PasswordSalt = new byte[] { 33, 214, 125, 145, 186, 227, 147, 138, 53, 105, 31, 28, 52, 81, 214, 72, 144, 163, 169, 14, 188, 178, 41, 22, 40, 163, 28, 108, 114, 130, 52, 82, 34, 97, 199, 173, 81, 206, 22, 149, 161, 53, 13, 233, 231, 232, 17, 219, 251, 136, 42, 221, 93, 17, 115, 24, 151, 114, 34, 128, 209, 58, 77, 191, 206, 178, 7, 217, 157, 148, 196, 181, 74, 102, 51, 48, 11, 139, 65, 31, 6, 72, 62, 94, 250, 67, 20, 93, 141, 250, 0, 65, 103, 35, 26, 28, 142, 32, 138, 67, 36, 72, 56, 233, 134, 237, 151, 224, 26, 72, 82, 102, 110, 158, 36, 16, 23, 115, 121, 229, 23, 216, 18, 204, 202, 51, 228, 229 }, Roles = "Admin,Dm,Player", Username = "admin" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
