﻿// <auto-generated />
using System;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
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

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessageBoard.Models.GroupMember", b =>
                {
                    b.HasOne("MessageBoard.Models.Group", "Group")
                        .WithMany("JoinGroups")
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
                        .WithMany("JoinMessages")
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
                        .WithMany("JoinMessages")
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
                    b.HasOne("MessageBoard.Models.Group", "group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.Member", "member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("group");

                    b.Navigation("member");
                });

            modelBuilder.Entity("MessageBoard.Models.Group", b =>
                {
                    b.Navigation("JoinGroups");

                    b.Navigation("JoinMessages");
                });

            modelBuilder.Entity("MessageBoard.Models.Member", b =>
                {
                    b.Navigation("JoinGroups");

                    b.Navigation("JoinMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
