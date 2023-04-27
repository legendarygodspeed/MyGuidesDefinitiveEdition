﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGuides.Infra.Data.Contexts.Database;

#nullable disable

namespace MyGuides.Infra.Data.Migrations
{
    [DbContext(typeof(MyGuidesContext))]
    partial class MyGuidesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyGuides.Domain.Entities.Achievements.Achievement", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("DifficultyId")
                        .HasColumnType("binary(16)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<byte[]>("GameId")
                        .IsRequired()
                        .HasColumnType("binary(16)");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("IconGray")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<long?>("Order")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("SectionId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("GameId");

                    b.HasIndex("SectionId");

                    b.ToTable("Achievement", (string)null);
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Banners.Banner", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<int>("BannerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("SectionId")
                        .IsRequired()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("BannerTypeId")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("Banner", (string)null);
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.BannerTypes.BannerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Hidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("BannerType", (string)null);

                    b.HasDiscriminator<int>("Id");
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Difficulties.Difficulty", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Difficulty", (string)null);
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Games.Game", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("AppId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Sections.Section", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsIndividual")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Section", (string)null);
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.BannerTypes.Types.Divisor", b =>
                {
                    b.HasBaseType("MyGuides.Domain.Entities.BannerTypes.BannerType");
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.BannerTypes.Types.Header", b =>
                {
                    b.HasBaseType("MyGuides.Domain.Entities.BannerTypes.BannerType");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Achievements.Achievement", b =>
                {
                    b.HasOne("MyGuides.Domain.Entities.Difficulties.Difficulty", "Difficulty")
                        .WithMany("Achievements")
                        .HasForeignKey("DifficultyId");

                    b.HasOne("MyGuides.Domain.Entities.Games.Game", "Game")
                        .WithMany("Achievements")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyGuides.Domain.Entities.Sections.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.Navigation("Difficulty");

                    b.Navigation("Game");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Banners.Banner", b =>
                {
                    b.HasOne("MyGuides.Domain.Entities.BannerTypes.BannerType", "BannerType")
                        .WithOne()
                        .HasForeignKey("MyGuides.Domain.Entities.Banners.Banner", "BannerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyGuides.Domain.Entities.Sections.Section", "Section")
                        .WithMany("Banners")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BannerType");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Difficulties.Difficulty", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Games.Game", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("MyGuides.Domain.Entities.Sections.Section", b =>
                {
                    b.Navigation("Banners");
                });
#pragma warning restore 612, 618
        }
    }
}
