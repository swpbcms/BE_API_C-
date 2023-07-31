namespace BCMS.DTO.Member
{
    public class updateMemberDTO
    {
        public string MemberId { get; set; }
        public bool? MemberGender { get; set; }
        public string? MemberImage { get; set; }
        public string? MemberFullName { get; set; }
        public string? MemberEmail { get; set; }
        public string? MemberPassword { get; set; }
        public DateTime? MemberDob { get; set; }

    }
}
