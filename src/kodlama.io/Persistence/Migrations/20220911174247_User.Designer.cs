﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220911174247_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthenticatorType = 0,
                            Email = "",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 230, 22, 246, 168, 183, 197, 213, 139, 126, 58, 4, 55, 21, 13, 234, 253, 31, 135, 35, 200, 160, 172, 203, 20, 188, 190, 130, 223, 186, 205, 135, 222, 127, 135, 66, 133, 253, 25, 146, 203, 8, 135, 4, 139, 175, 73, 53, 237, 183, 216, 145, 211, 189, 234, 0, 140, 160, 142, 160, 135, 74, 105, 17, 64 },
                            PasswordSalt = new byte[] { 56, 30, 115, 77, 83, 2, 89, 35, 219, 74, 84, 66, 233, 6, 82, 190, 193, 200, 44, 78, 160, 208, 186, 165, 175, 50, 192, 134, 92, 151, 145, 157, 58, 150, 214, 143, 205, 131, 106, 205, 105, 111, 196, 148, 42, 50, 127, 123, 153, 195, 215, 49, 103, 112, 81, 182, 162, 228, 239, 24, 0, 73, 116, 189, 137, 169, 79, 62, 99, 38, 18, 44, 97, 62, 26, 206, 17, 68, 91, 158, 210, 24, 239, 248, 147, 57, 79, 208, 250, 112, 115, 156, 158, 247, 207, 20, 146, 25, 197, 26, 180, 132, 24, 17, 56, 65, 177, 88, 94, 45, 97, 249, 95, 222, 52, 163, 243, 110, 237, 40, 136, 128, 3, 201, 103, 27, 24, 130 },
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            AuthenticatorType = 0,
                            Email = "",
                            FirstName = "User",
                            LastName = "User",
                            PasswordHash = new byte[] { 230, 22, 246, 168, 183, 197, 213, 139, 126, 58, 4, 55, 21, 13, 234, 253, 31, 135, 35, 200, 160, 172, 203, 20, 188, 190, 130, 223, 186, 205, 135, 222, 127, 135, 66, 133, 253, 25, 146, 203, 8, 135, 4, 139, 175, 73, 53, 237, 183, 216, 145, 211, 189, 234, 0, 140, 160, 142, 160, 135, 74, 105, 17, 64 },
                            PasswordSalt = new byte[] { 56, 30, 115, 77, 83, 2, 89, 35, 219, 74, 84, 66, 233, 6, 82, 190, 193, 200, 44, 78, 160, 208, 186, 165, 175, 50, 192, 134, 92, 151, 145, 157, 58, 150, 214, 143, 205, 131, 106, 205, 105, 111, 196, 148, 42, 50, 127, 123, 153, 195, 215, 49, 103, 112, 81, 182, 162, 228, 239, 24, 0, 73, 116, 189, 137, 169, 79, 62, 99, 38, 18, 44, 97, 62, 26, 206, 17, 68, 91, 158, 210, 24, 239, 248, 147, 57, 79, 208, 250, 112, 115, 156, 158, 247, 207, 20, 146, 25, 197, 26, 180, 132, 24, 17, 56, 65, 177, 88, 94, 45, 97, 249, 95, 222, 52, 163, 243, 110, 237, 40, 136, 128, 3, 201, 103, 27, 24, 130 },
                            Status = true
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int")
                        .HasColumnName("OperationClaimId");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UserId", "OperationClaimId");

                    b.HasIndex("OperationClaimId");

                    b.ToTable("UserOperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            OperationClaimId = 1,
                            Id = 0
                        },
                        new
                        {
                            UserId = 2,
                            OperationClaimId = 2,
                            Id = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.GithubAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("GithubAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Url = "",
                            UserId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Url = "",
                            UserId = 2,
                            Username = "user"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgramingLanguages", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProgramingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgramingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramingLanguageId");

                    b.ToTable("Technologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Spring",
                            ProgramingLanguageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jsp",
                            ProgramingLanguageId = 1
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.GithubAccount", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.HasOne("Domain.Entities.ProgramingLanguage", "ProgramingLanguage")
                        .WithMany("Technologies")
                        .HasForeignKey("ProgramingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramingLanguage");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Navigation("Technologies");
                });
#pragma warning restore 612, 618
        }
    }
}
