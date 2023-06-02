﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Models
{
    [Index("MemberUserName", Name = "IX_Member", IsUnique = true)]
    [Index("MemberEmail", Name = "IX_Member_1", IsUnique = true)]
    public partial class Member
    {
        public Member()
        {
            Comment = new HashSet<Comment>();
            JoinEvent = new HashSet<JoinEvent>();
            Like = new HashSet<Like>();
            Notification = new HashSet<Notification>();
            Post = new HashSet<Post>();
            Report = new HashSet<Report>();
        }

        [Key]
        [Column("MemberID")]
        [StringLength(10)]
        public string MemberId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime MemberCreateAt { get; set; }
        public bool MemberGender { get; set; }
        [Required]
        public string MemberImage { get; set; }
        [Required]
        [StringLength(100)]
        public string MemberFullName { get; set; }
        [Required]
        [StringLength(100)]
        public string MemberEmail { get; set; }
        [Column("MemberDOB", TypeName = "date")]
        public DateTime MemberDob { get; set; }
        public bool MemberStatus { get; set; }
        [Required]
        [StringLength(50)]
        public string MemberUserName { get; set; }
        [Required]
        [StringLength(50)]
        public string MemberPassword { get; set; }

        [InverseProperty("Member")]
        public virtual ICollection<Comment> Comment { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<JoinEvent> JoinEvent { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Like> Like { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Notification> Notification { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Post> Post { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Report> Report { get; set; }
    }
}