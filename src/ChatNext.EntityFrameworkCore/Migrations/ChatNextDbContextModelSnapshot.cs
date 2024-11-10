﻿// <auto-generated />
using System;
using ChatNext.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatNext.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ChatNextDbContext))]
    partial class ChatNextDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ChatNext.Domain.Chat.Messages", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("createdat");

                    b.Property<Guid?>("Creator")
                        .HasColumnType("TEXT")
                        .HasColumnName("creator");

                    b.Property<string>("Files")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("files");

                    b.Property<string>("FromModel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("frommodel");

                    b.Property<Guid?>("Modifier")
                        .HasColumnType("TEXT")
                        .HasColumnName("modifier");

                    b.Property<string>("ParentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("parentid");

                    b.Property<string>("Plugin")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("plugin");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role");

                    b.Property<long>("SessionId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("sessionid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updatedat");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Role");

                    b.HasIndex("SessionId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("ChatNext.Domain.Chat.Plugins", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("avatar");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("FunctionName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("functionname");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("identifier");

                    b.Property<string>("SystemRole")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("systemrole");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("type");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("version");

                    b.HasKey("Id");

                    b.HasIndex("FunctionName");

                    b.HasIndex("Type");

                    b.HasIndex("Version");

                    b.ToTable("plugins");
                });

            modelBuilder.Entity("ChatNext.Domain.Chat.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("avatar");

                    b.Property<string>("Config")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("config");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("createdat");

                    b.Property<Guid?>("Creator")
                        .HasColumnType("TEXT")
                        .HasColumnName("creator");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("TEXT")
                        .HasColumnName("groupid");

                    b.Property<int>("HistoryLimit")
                        .HasColumnType("INTEGER")
                        .HasColumnName("historylimit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("model");

                    b.Property<Guid?>("Modifier")
                        .HasColumnType("TEXT")
                        .HasColumnName("modifier");

                    b.Property<bool>("Pinned")
                        .HasColumnType("INTEGER")
                        .HasColumnName("pinned");

                    b.Property<string>("Plugins")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("plugins");

                    b.Property<float>("PresencePenalty")
                        .HasColumnType("REAL")
                        .HasColumnName("presencepenalty");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("provider");

                    b.Property<string>("SystemRole")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("systemrole");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tags");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL")
                        .HasColumnName("temperature");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<float>("TopP")
                        .HasColumnType("REAL")
                        .HasColumnName("topp");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updatedat");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("GroupId");

                    b.HasIndex("Title");

                    b.ToTable("sessions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Avatar = "https://registry.npmmirror.com/@lobehub/fluent-emoji-3d/1.1.0/files/assets/1f92f.webp",
                            Config = "{\"$id\":\"1\"}",
                            CreatedAt = new DateTime(2024, 11, 11, 0, 40, 10, 885, DateTimeKind.Local).AddTicks(8691),
                            Creator = new Guid("745c2272-c49e-439c-b80b-926d21fc50c4"),
                            Description = "Default",
                            GroupId = new Guid("6205d3b7-ef0c-4734-9dc7-38ad18b7e964"),
                            HistoryLimit = -1,
                            Model = "gpt-4o",
                            Pinned = false,
                            Plugins = "[]",
                            PresencePenalty = 0f,
                            Provider = "openai",
                            SystemRole = "",
                            Tags = "[]",
                            Temperature = 1f,
                            Title = "Default",
                            TopP = 1f
                        });
                });

            modelBuilder.Entity("ChatNext.Domain.Chat.SessionGroups", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("createdat");

                    b.Property<Guid?>("Creator")
                        .HasColumnType("TEXT")
                        .HasColumnName("creator");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("INTEGER")
                        .HasColumnName("isdefault");

                    b.Property<Guid?>("Modifier")
                        .HasColumnType("TEXT")
                        .HasColumnName("modifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Sort")
                        .HasColumnType("INTEGER")
                        .HasColumnName("sort");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updatedat");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Name");

                    b.ToTable("sessiongroups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6205d3b7-ef0c-4734-9dc7-38ad18b7e964"),
                            CreatedAt = new DateTime(2024, 11, 11, 0, 40, 10, 885, DateTimeKind.Local).AddTicks(8662),
                            Creator = new Guid("745c2272-c49e-439c-b80b-926d21fc50c4"),
                            IsDefault = false,
                            Name = "Default",
                            Sort = 0
                        });
                });

            modelBuilder.Entity("ChatNext.Domain.Storage.FileStorage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("createdat");

                    b.Property<Guid?>("Creator")
                        .HasColumnType("TEXT")
                        .HasColumnName("creator");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("data");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("filetype");

                    b.Property<Guid?>("Modifier")
                        .HasColumnType("TEXT")
                        .HasColumnName("modifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("SaveMode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("savemode");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER")
                        .HasColumnName("size");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updatedat");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("FileType");

                    b.HasIndex("Name");

                    b.ToTable("filestorages");
                });

            modelBuilder.Entity("ChatNext.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("createdat");

                    b.Property<Guid?>("Creator")
                        .HasColumnType("TEXT")
                        .HasColumnName("creator");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("firstname");

                    b.Property<DateTime?>("LastLoginErrorTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("lastloginerrortime");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("lastlogintime");

                    b.Property<string>("LatestName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("latestname");

                    b.Property<int>("LoginErrorCount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("loginerrorcount");

                    b.Property<Guid?>("Modifier")
                        .HasColumnType("TEXT")
                        .HasColumnName("modifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("passwordsalt");

                    b.Property<byte>("State")
                        .HasColumnType("INTEGER")
                        .HasColumnName("state");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updatedat");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("State");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("745c2272-c49e-439c-b80b-926d21fc50c4"),
                            Avatar = "https://chat-preview.lobehub.com/icons/icon-192x192.png",
                            CreatedAt = new DateTime(2024, 11, 11, 0, 40, 10, 885, DateTimeKind.Local).AddTicks(7944),
                            Email = "239573049@qq.com",
                            FirstName = "Admin",
                            LatestName = "Admin",
                            LoginErrorCount = 0,
                            Password = "81c75bd7a12542812272bd2b6d3096f1962d66b10588e910bd2bf80a45ff30ec",
                            PasswordSalt = "e9868438e42647a88ecb528d5da25faa",
                            State = (byte)1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("ChatNext.Domain.Users.UserOAuthExtension", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Extra")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("extra");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("provider");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("providerkey");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("Provider");

                    b.HasIndex("ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("useroauthextensions");
                });
#pragma warning restore 612, 618
        }
    }
}
