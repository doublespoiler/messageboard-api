using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Models
{
    public class Group
    {
      public Group()
      {
        this.JoinGroups = new HashSet<GroupMember>();
        this.JoinMessages = new HashSet<GroupMessage>();
        this.GroupCreated = DateTime.Now;
      }

      public int GroupId { get; set; }
      public string GroupTitle { get; set; }
      public string GroupTopic { get; set; }
      public string GroupColor { get; set; }
      public DateTime GroupCreated { get; }
      
      public virtual ICollection<GroupMember> JoinGroups { get; set; }
      public virtual ICollection<GroupMessage> JoinMessages { get; set; }
    }
}