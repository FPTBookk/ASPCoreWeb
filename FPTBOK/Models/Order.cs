﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    public partial class Order{

    [Key]
    public int Id { get; set; }
    public string UserId {get; set;}
    public DateTime TimeOrder {get; set;}
    public string Address {get; set;}
    public string Status {get;set;}

    [InverseProperty("IdOrderNavigation")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
 
}
}
