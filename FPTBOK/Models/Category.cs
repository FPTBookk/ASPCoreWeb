using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Detail { get; set; } = null!;
        [StringLength(20)]
        public string Status { get; set; } = null!;
    }
}
