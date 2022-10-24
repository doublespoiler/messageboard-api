using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Models
{
    public class GroupMessage
    {
      public int GroupMessageId { get; set; }
      public int GroupId { get; set; }
      public int MessageId { get; set; }
      public virtual Group Group { get; set; }
      public virtual Message Message { get; set; }
    }
}