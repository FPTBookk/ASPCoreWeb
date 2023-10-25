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
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        public byte? Status { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Description { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
