using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Models
{
    public class GroupMember
    {
      public int GroupMemberId { get; set; }
      public int GroupId { get; set; }
      public int MemberId { get; set; }
      public virtual Group Group { get; set; }
      public virtual Member Member { get; set; }
    }
}