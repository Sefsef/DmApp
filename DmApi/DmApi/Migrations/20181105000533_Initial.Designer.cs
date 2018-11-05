﻿// <auto-generated />
using DnDApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DnDApi.Migrations
{
    [DbContext(typeof(SpellContext))]
    [Migration("20181105000533_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("DnDApi.Models.Spell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("School");

                    b.HasKey("ID");

                    b.ToTable("Spells");
                });
#pragma warning restore 612, 618
        }
    }
}