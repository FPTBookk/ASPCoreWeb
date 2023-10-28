using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    public partial class OrderDetail{

    [Key]
    public int Id { get; set; }
    public int ProductId {get; set;}
    public int OrderId {get; set;}
    public decimal Price   {get; set;}

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product? IdProOrderNavigation { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order? IdOrderNavigation { get; set; } = null!;
}

}
