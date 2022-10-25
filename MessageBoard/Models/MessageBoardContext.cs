using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base (options) { }

    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<GroupMember> GroupMember { get; set; }
    public DbSet<GroupMessage> GroupMessage { get; set; }
    public DbSet<MemberMessage> MemberMessage { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>().HasData
      (
        new Message 
        { 
          MessageId = 1,
          MessageTitle = "Hello World",
          MessageText = "Hello World",
          GroupId = 1,
          MemberId = 1
        },
        new Message
        {
          MessageId = 2,
          MessageTitle = "Goodbye World",
          MessageText = "Goodbye World",
          GroupId = 1,
          MemberId = 2
        },
        new Message
        {
          MessageId = 3,
          MessageTitle = "Nintendo Switch",
          MessageText = "Nintendo",
          GroupId = 2,
          MemberId = 2
        }
      );
      builder.Entity<Group>().HasData
      (
        new Group 
        {
          GroupId = 1,
          GroupTitle = "Main",
          GroupTopic = "This is the main group",
          GroupColor = "#fff"
        },
        new Group 
        {
          GroupId = 2,
          GroupTitle = "Nintendo",
          GroupTopic = "Nintendo Switch",
          GroupColor = "#ff0000"
        },
        new Group 
        {
          GroupId = 3,
          GroupTitle = "Programming",
          GroupTopic = "For Programmers",
          GroupColor = "#00ff00"
        }
      );
      builder.Entity<Member>().HasData
      (
        new Member
        {
          MemberId = 1,
          MemberName = "Skylan",
          MemberCharacter = 'S',
          MemberColor = "#ff8000"
        },
        new Member
        {
          MemberId = 2,
          MemberName = "Will",
          MemberCharacter = 'W',
          MemberColor = "#0000ff"
        }
      );
      // builder.Entity<GroupMessage>().HasData
      // (
      //   new GroupMessage
      //   {
      //     GroupMessageId = 1,
      //     GroupId = 1,
      //     MessageId = 1
      //   },
      //   new GroupMessage
      //   {
      //     GroupMessageId = 2,
      //     GroupId = 1,
      //     MessageId = 2
      //   },
      //   new GroupMessage
      //   {
      //     GroupMessageId = 3,
      //     GroupId = 2,
      //     MessageId = 3
      //   }
      // );
      builder.Entity<GroupMember>().HasData
      (
        new GroupMember
        {
          GroupMemberId = 1,
          GroupId = 1,
          MemberId = 1
        },
        new GroupMember
        {
          GroupMemberId = 2,
          GroupId = 1,
          MemberId = 2
        },
        new GroupMember
        {
          GroupMemberId = 3,
          GroupId = 2,
          MemberId = 2
        },
        new GroupMember
        {
          GroupMemberId = 4,
          GroupId = 3,
          MemberId = 1
        }
      );
      // builder.Entity<MemberMessage>().HasData
      // (
      //   new MemberMessage
      //   {
      //     MemberMessageId = 1,
      //     MemberId = 1,
      //     MessageId = 1
      //   },
      //   new MemberMessage 
      //   {
      //     MemberMessageId = 2,
      //     MemberId = 2,
      //     MessageId = 2
      //   },
      //   new MemberMessage
      //   {
      //     MemberMessageId = 3,
      //     MemberId = 2,
      //     MessageId = 3
      //   }
      // );
    }
  }
}