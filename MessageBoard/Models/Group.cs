using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
    public class Group
    {
      public Group()
      {
        this.JoinMembers = new HashSet<GroupMember>();
        this.JoinMessages = new HashSet<GroupMessage>();
        this.GroupCreated = DateTime.Now;
      }

      public int GroupId { get; set; }
      [Required]
      [StringLength(25, ErrorMessage = "Group Title must be between 0 and 25 characters")]
      public string GroupTitle { get; set; }
      [StringLength(25, ErrorMessage = "Group Topic must be between 0 and 25 characters")]
      public string GroupTopic { get; set; }
      public string GroupColor { get; set; } = "#fff";
      public DateTime GroupCreated { get; set; }
      
      public virtual ICollection<GroupMember> JoinMembers { get; set; }
      public virtual ICollection<GroupMessage> JoinMessages { get; set; }
    }
}