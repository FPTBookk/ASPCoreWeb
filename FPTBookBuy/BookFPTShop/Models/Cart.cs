using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookFPTShop.Models
{
    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("Carts")]
        public virtual OrderBook? Order { get; set; }
    }
}
