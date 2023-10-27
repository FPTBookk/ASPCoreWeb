using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Models
{
    public partial class Cart
    {
        [Key]
        public int Id { get; set; }
        public string UserId {get;set;}
        public int ProductID {get;set;}
        public decimal Price {get;set;}
        [ForeignKey("ProductID")]
        [InverseProperty("Carts")]
        public virtual Product? IdProNavigation{get;set;} = null;
    }
}
