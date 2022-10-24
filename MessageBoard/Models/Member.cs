using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Models
{
    public class Member
    {
        public Member()
        {
          this.JoinMessages = new HashSet<MemberMessage>();
          this.JoinGroups = new HashSet<GroupMember>();
          this.MemberCreated = DateTime.Now;
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public char MemberCharacter { get; set; }
        public string MemberColor { get; set; }
        public DateTime MemberCreated { get; }

        public virtual ICollection<GroupMember> JoinGroups { get; }
        public virtual ICollection<MemberMessage> JoinMessages { get; }
    }
}