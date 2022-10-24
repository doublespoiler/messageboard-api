using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Message
  {
    public Message()
    {
      this.JoinGroups = new HashSet<GroupMessage>();
      this.JoinMembers = new HashSet<MemberMessage>();
      this.MessageCreated = DateTime.Now;
    }

    public int MessageId { get; set; }
    public int ParentId { get; set; }
    [Range(3, 100, ErrorMessage = "Message Title has a limit of 100 characters")]
    public string MessageTitle { get; set; }
    [Required]
    [Range(3, 999, ErrorMessage = "Message Text has a limit of 999 characters")]
    public string MessageText { get; set; }
    public DateTime MessageCreated { get; }

    public virtual ICollection<GroupMessage> JoinGroups { get; set; }
    public virtual ICollection<MemberMessage> JoinMembers { get; set; }

  }
}