using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MessageBoard.Models
{
    public class Group
    {
      public Group()
      {
        this.JoinMembers = new HashSet<GroupMember>();
        this.Messages = new HashSet<Message>();
        this.GroupCreated = DateTime.UtcNow;
      }

      public int GroupId { get; set; }
      [Required]
      [StringLength(25, ErrorMessage = "Group Title must be between 0 and 25 characters")]
      public string GroupTitle { get; set; }
      [StringLength(25, ErrorMessage = "Group Topic must be between 0 and 25 characters")]
      public string GroupTopic { get; set; }
      public string GroupColor { get; set; } = "#fff";
      public DateTime GroupCreated { get; set; }
      
      [JsonIgnore]
      public virtual ICollection<GroupMember> JoinMembers { get; set; }
      [JsonIgnore]
      public virtual ICollection<Message> Messages { get; set; }
    }
}