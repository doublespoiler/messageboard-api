using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [StringLength(25, ErrorMessage = "Username must be between 3 and 25 characters.")]
        public string MemberName { get; set; }
        [StringLength(1, ErrorMessage = "Character can be only 1 character")]
        public char MemberCharacter { get; set; } = '@';
        public string MemberColor { get; set; } = "#fff";
        public DateTime MemberCreated { get; set; }

        public virtual ICollection<GroupMember> JoinGroups { get; }
        public virtual ICollection<MemberMessage> JoinMessages { get; }
    }
}