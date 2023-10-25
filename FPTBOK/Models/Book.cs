using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Title { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? ImageBook { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Descript { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Books")]
        public virtual Category? Category { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
