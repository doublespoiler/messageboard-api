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
      this.MessageCreated = DateTime.UtcNow;
    }

    public int MessageId { get; set; }
    public int ParentId { get; set; } = 0;
    [StringLength(100, ErrorMessage = "Message Title has a limit of 100 characters")]
    public string MessageTitle { get; set; }
    [Required]
    [StringLength(999,  ErrorMessage = "Message Text has a limit of 999 characters")]
    public string MessageText { get; set; }
    public DateTime MessageCreated { get; set; }
    public int GroupId { get; set; }
    public int MemberId { get; set; }

    public virtual Group group { get; set; }
    public virtual Member member { get; set; }
    public virtual Message parent { get; set; }

  }
}