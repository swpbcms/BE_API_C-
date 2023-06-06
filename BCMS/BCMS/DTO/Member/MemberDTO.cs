using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Member
{
    public class MemberDTO
    {
        public string MemberId { get; set; }
        public DateTime MemberCreateAt { get; set; }
        public bool MemberGender { get; set; }
        public string MemberImage { get; set; }
        public string MemberFullName { get; set; }
        public string MemberEmail { get; set; }
        public DateTime MemberDob { get; set; }
        public bool MemberStatus { get; set; }        
        public string MemberUserName { get; set; }       
        public string MemberPassword { get; set; }
    }
}
