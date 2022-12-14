using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MessageBoard.Models
{
    public class Member
    {
        public Member()
        {
          this.Messages = new HashSet<Message>();
          this.JoinGroups = new HashSet<GroupMember>();
          this.MemberCreated = DateTime.UtcNow;
        }

        public int MemberId { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Username must be between 3 and 25 characters.")]
        public string MemberName { get; set; }
        [StringLength(1, ErrorMessage = "Character can be only 1 character")]
        public string MemberCharacter { get; set; } = "@";
        public string MemberColor { get; set; } = "#fff";
        public DateTime MemberCreated { get; set; }

        [JsonIgnore]
        public virtual ICollection<GroupMember> JoinGroups { get; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; }
    }
}