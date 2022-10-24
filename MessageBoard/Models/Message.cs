using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    public string MessageTitle { get; set; }
    public string MessageText { get; set; }
    public DateTime MessageCreated { get; }

    public virtual ICollection<GroupMessage> JoinGroups { get; set; }
    public virtual ICollection<MemberMessage> JoinMembers { get; set; }

  }
}