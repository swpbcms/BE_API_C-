﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Models
{
    public partial class Media
    {
        [Key]
        [Column("MediaID")]
        [StringLength(10)]
        public string MediaId { get; set; }
        [Column("PostID")]
        [StringLength(10)]
        public string PostId { get; set; }
        [Required]
        public string LinkMedia { get; set; }
        public bool Status { get; set; }
        [StringLength(10)]
        public string BlogId { get; set; }

        [ForeignKey("BlogId")]
        [InverseProperty("Media")]
        public virtual Blog Blog { get; set; }
        [ForeignKey("PostId")]
        [InverseProperty("Media")]
        public virtual Post Post { get; set; }
    }
}