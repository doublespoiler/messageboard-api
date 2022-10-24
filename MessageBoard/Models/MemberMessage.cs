using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Models
{
    public class MemberMessage
    {
      public int MemberMessageId { get; set; }
      public int MemberId { get; set; }
      public int MessageId { get; set; }
      public virtual Member Member { get; set; }
      public virtual Message Message { get; set; }
    }
}