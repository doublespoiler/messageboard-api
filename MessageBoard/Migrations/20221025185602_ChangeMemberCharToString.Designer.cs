﻿// <auto-generated />
using System;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    [Migration("20221025185602_ChangeMemberCharToString")]
    partial class ChangeMemberCharToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MessageBoard.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GroupColor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("GroupCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4");

                    b.Property<string>("GroupTopic")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupColor = "#fff",
                            GroupCreated = new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(65),
                            GroupTitle = "Main",
                            GroupTopic = "This is the main group"
                        },
                        new
                        {
                            GroupId = 2,
                            GroupColor = "#ff0000",
                            GroupCreated = new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(954),
                            GroupTitle = "Nintendo",
                            GroupTopic = "Nintendo Switch"
                        },
                        new
                        {
                            GroupId = 3,
                            GroupColor = "#00ff00",
                            GroupCreated = new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(957),
                            GroupTitle = "Programming",
                            GroupTopic = "For Programmers"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.GroupMember", b =>
                {
                    b.Property<int>("GroupMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("GroupMemberId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("GroupMember");

                    b.HasData(
                        new
                        {
                            GroupMemberId = 1,
                            GroupId = 1,
                            MemberId = 1
                        },
                        new
                        {
                            GroupMemberId = 2,
                            GroupId = 1,
                            MemberId = 2
                        },
                        new
                        {
                            GroupMemberId = 3,
                            GroupId = 2,
                            MemberId = 2
                        },
                        new
                        {
                            GroupMemberId = 4,
                            GroupId = 3,
                            MemberId = 1
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.GroupMessage", b =>
                {
                    b.Property<int>("GroupMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("GroupMessageId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MessageId");

                    b.ToTable("GroupMessage");
                });

            modelBuilder.Entity("MessageBoard.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MemberCharacter")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4");

                    b.Property<string>("MemberColor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("MemberCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25) CHARACTER SET utf8mb4");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            MemberCharacter = "S",
                            MemberColor = "#ff8000",
                            MemberCreated = new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(1819),
                            MemberName = "Skylan"
                        },
                        new
                        {
                            MemberId = 2,
                            MemberCharacter = "W",
                            MemberColor = "#0000ff",
                            MemberCreated = new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(2629),
                            MemberName = "Will"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.MemberMessage", b =>
                {
                    b.Property<int>("MemberMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("MemberMessageId");

                    b.HasIndex("MemberId");

                    b.HasIndex("MessageId");

                    b.ToTable("MemberMessage");
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MessageCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(999)
                        .HasColumnType("varchar(999) CHARACTER SET utf8mb4");

                    b.Property<string>("MessageTitle")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.HasKey("MessageId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            GroupId = 1,
                            MemberId = 1,
                            MessageCreated = new DateTime(2022, 10, 25, 18, 56, 1, 822, DateTimeKind.Utc).AddTicks(8903),
                            MessageText = "Hello World",
                            MessageTitle = "Hello World"
                        },
                        new
                        {
                            MessageId = 2,
                            GroupId = 1,
                            MemberId = 2,
                            MessageCreated = new DateTime(2022, 10, 25, 18, 56, 1, 823, DateTimeKind.Utc).AddTicks(602),
                            MessageText = "Goodbye World",
                            MessageTitle = "Goodbye World"
                        },
                        new
                        {
                            MessageId = 3,
                            GroupId = 2,
                            MemberId = 2,
                            MessageCreated = new DateTime(2022, 10, 25, 18, 56, 1, 823, DateTimeKind.Utc).AddTicks(606),
                            MessageText = "Nintendo",
                            MessageTitle = "Nintendo Switch"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.GroupMember", b =>
                {
                    b.HasOne("MessageBoard.Models.Group", "Group")
                        .WithMany("JoinMembers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.Member", "Member")
                        .WithMany("JoinGroups")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MessageBoard.Models.GroupMessage", b =>
                {
                    b.HasOne("MessageBoard.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("MessageBoard.Models.MemberMessage", b =>
                {
                    b.HasOne("MessageBoard.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.HasOne("MessageBoard.Models.Group", "Group")
                        .WithMany("Messages")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.Member", "Member")
                        .WithMany("Messages")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MessageBoard.Models.Group", b =>
                {
                    b.Navigation("JoinMembers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("MessageBoard.Models.Member", b =>
                {
                    b.Navigation("JoinGroups");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
