using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column("OrderDetailID")]
        public int OrderDetailId { get; set; }
        [Column("BookID")]
        public int? BookId { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty("OrderDetails")]
        public virtual Book? Book { get; set; }
        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public virtual OrderBook? Order { get; set; }
    }
}
