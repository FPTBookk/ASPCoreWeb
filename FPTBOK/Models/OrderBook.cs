using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    [Table("OrderBook")]
    public partial class OrderBook
    {
        public OrderBook()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Address { get; set; }
        public int? TotalAmount { get; set; }
        public byte? OrderStatus { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<Cart> Carts { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
