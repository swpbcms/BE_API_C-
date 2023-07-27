﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Models
{
    public partial class Report
    {
        [Key]
        [Column("ReportID")]
        [StringLength(10)]
        public string ReportId { get; set; }
        [Required]
        [StringLength(50)]
        public string ReportTitle { get; set; }
        [Column("ManagerID")]
        [StringLength(10)]
        public string ManagerId { get; set; }
        [Required]
        [Column("MemberID")]
        [StringLength(10)]
        public string MemberId { get; set; }
        [Required]
        [StringLength(10)]
        public string ReportType { get; set; }
        public bool ReportStatus { get; set; }
        [Required]
        public string ReportDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public string Reply { get; set; }
        [Column("postId")]
        [StringLength(10)]
        public string PostId { get; set; }

        [ForeignKey("ManagerId")]
        [InverseProperty("Report")]
        public virtual Manager Manager { get; set; }
        [ForeignKey("MemberId")]
        [InverseProperty("Report")]
        public virtual Member Member { get; set; }
        [ForeignKey("PostId")]
        [InverseProperty("Report")]
        public virtual Post Post { get; set; }
        [ForeignKey("ReportType")]
        [InverseProperty("Report")]
        public virtual ReportType ReportTypeNavigation { get; set; }
    }
}