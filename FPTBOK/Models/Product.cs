using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    [Table("Product")]
    [Index("IdCat", Name = "IX_Product_IdCat")]
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [StringLength(50)]
        public string? Image { get; set; }
        public int? IdCat { get; set; }
    }
}
